using System;
using System.Data;
using System.Data.SQLite;
using System.Collections;
using System.Threading;
using System.IO;

namespace PIDMicrosoft
{
    class KeyDatabase
    {
        public SQLiteConnection m_connection = new SQLiteConnection("Data Source=key_database.db;Version=3;");
        public bool m_isDatabaseLocked = false;
        public void InitDB()
        {
            if(!File.Exists("key_database.db"))
            {
                SQLiteConnection.CreateFile("key_database.db");
            }
        }
        public void ConnectToDB()
        {
            while (m_isDatabaseLocked) {
                Thread.Sleep(10);
            };
            m_isDatabaseLocked = true;
            m_connection.Open();
        }

        public void CloseDB()
        {
            m_connection.Close();
            m_isDatabaseLocked = false;
        }
        public ArrayList GetTables()
        {
            this.ConnectToDB();

            ArrayList list = new ArrayList();

            // executes query that select names of all tables in master table of the database
            string query = "SELECT name FROM sqlite_master " +
                    "WHERE type = 'table'" +
                    "ORDER BY 1";

            DataTable dt = new DataTable();

            using (SQLiteCommand cmd = new SQLiteCommand(query, m_connection))
            {
                using (SQLiteDataReader rdr = cmd.ExecuteReader()){
                    dt.Load(rdr);
                }
            }

            // Return all table names in the ArrayList

            foreach (DataRow row in dt.Rows){
                list.Add(row.ItemArray[0].ToString());
            }

            this.CloseDB();

            return list;
        }
        
        public void UpdateKeyInDB(KeyDetail detail)
        {
            string tableName = detail.prd;

            this.ConnectToDB();

            SQLiteCommand sqlite_cmd = m_connection.CreateCommand();

            sqlite_cmd.CommandText = String.Format(@"UPDATE '" + tableName + "' SET Activation_Count = '{0}', Error_Code = '{1}', Time = '{2}' WHERE Product_Key = '{3}';",
                                     detail.activationCount, detail.errorCode, detail.time, detail.key);

            sqlite_cmd.ExecuteNonQuery();

            this.CloseDB();
        }

        public void AddKeyToDB(KeyDetail detail)
        {
            this.ConnectToDB();
            
            string tableName = detail.prd;

            //check table name exist
            SQLiteCommand table_cmd = m_connection.CreateCommand();

            table_cmd.CommandText = @" CREATE TABLE IF NOT EXISTS '" + tableName + @"' (
                                        Product_Key text PRIMARY KEY,
                                        Product_ID text,
                                        Advanced_PID text,
                                        Activation_ID text,
                                        Edition_Type text,
                                        Sub_Type text,
                                        Key_Type text,
                                        Eula text,
                                        Crypto_ID text,
                                        Activation_Count integer,
                                        Error_Code text,
                                        Time text
                                    ); ";
            table_cmd.ExecuteNonQuery();

            //add key to table
            SQLiteCommand sqlite_cmd = m_connection.CreateCommand();
            sqlite_cmd.CommandText = String.Format(@"INSERT INTO '" + tableName + @"' (Product_Key, Product_ID, Advanced_PID, Activation_ID,
                                            Edition_Type, Sub_Type, Key_Type, Eula, Crypto_ID, Activation_Count, Error_Code, Time) 
                                            VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}');",
                                       detail.key, detail.keypid, detail.eid, detail.aid,
                                       detail.edi, detail.sub, detail.lit, detail.lic, detail.cid,
                                       detail.activationCount, detail.errorCode, detail.time);
            sqlite_cmd.ExecuteNonQuery();

            this.CloseDB();
        }

        public void DeleteKeyInDB(string tableName, string key)
        {
            this.ConnectToDB();

            //delete it
            SQLiteCommand sqlite_cmd = m_connection.CreateCommand();

            sqlite_cmd.CommandText = String.Format(@"DELETE FROM '" + tableName + "' WHERE Product_Key = '{0}';", key);

            sqlite_cmd.ExecuteNonQuery();

            this.CloseDB();
        }

        public void DeleteTableInDB(string tableName)
        {
            this.ConnectToDB();

            //delete it
            SQLiteCommand sqlite_cmd = m_connection.CreateCommand();

            sqlite_cmd.CommandText = String.Format(@"DROP TABLE '" + tableName + "';");

            sqlite_cmd.ExecuteNonQuery();

            this.CloseDB();
        }

        public ArrayList GetAllKeyFromTable(string tableName)
        {
            ArrayList list = new ArrayList();

            this.ConnectToDB();

            string query = "SELECT * FROM '" + tableName + "';";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, m_connection))
                {
                    using (SQLiteDataReader sqlite_datareader = cmd.ExecuteReader())
                    {
                        while (sqlite_datareader.Read())
                        {
                            KeyDetail detail = new KeyDetail(sqlite_datareader.GetString(0));
                            detail.keypid = sqlite_datareader.GetString(1);
                            detail.eid = sqlite_datareader.GetString(2);
                            detail.aid = sqlite_datareader.GetString(3);
                            detail.edi = sqlite_datareader.GetString(4);
                            detail.sub = sqlite_datareader.GetString(5);
                            detail.lit = sqlite_datareader.GetString(6);
                            detail.lic = sqlite_datareader.GetString(7);
                            detail.cid = sqlite_datareader.GetString(8);
                            detail.activationCount = sqlite_datareader.GetInt32(9);
                            detail.errorCode = sqlite_datareader.GetString(10);
                            detail.time = sqlite_datareader.GetString(11);
                            detail.prd = tableName;

                            list.Add(detail);
                        }
                    }
                }
            }
            catch (Exception e) { };

            this.CloseDB();

            return list;
        }

        public KeyDetail GetKeyDetail(string key)
        {
            KeyDetail detail = null;

            ArrayList tables = GetTables();

            this.ConnectToDB();

            for (int i = 0; i < tables.Count; i++)
            {
                string query = "SELECT * FROM '" + tables[i].ToString() + "' WHERE Product_Key = '" + key + "'";
                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(query, m_connection))
                    {
                        using (SQLiteDataReader sqlite_datareader = cmd.ExecuteReader())
                        {
                            if (sqlite_datareader.Read())
                            {
                                detail = new KeyDetail(key);
                                detail.keypid = sqlite_datareader.GetString(1);
                                detail.eid = sqlite_datareader.GetString(2);
                                detail.aid = sqlite_datareader.GetString(3);
                                detail.edi = sqlite_datareader.GetString(4);
                                detail.sub = sqlite_datareader.GetString(5);
                                detail.lit = sqlite_datareader.GetString(6);
                                detail.lic = sqlite_datareader.GetString(7);
                                detail.cid = sqlite_datareader.GetString(8);
                                detail.activationCount = sqlite_datareader.GetInt32(9);
                                detail.errorCode = sqlite_datareader.GetString(10);
                                detail.time = sqlite_datareader.GetString(11);
                                detail.prd = tables[i].ToString();

                                break;
                            }
                        }
                    }
                }
                catch (Exception e) { };
            }

            this.CloseDB();

            return detail;
        }

        public KeyDetail GetUncompletedKeyDetail(string uncompletedKey)
        {
            KeyDetail detail = null;

            ArrayList tables = GetTables();

            this.ConnectToDB();

            try
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    SQLiteCommand sqlite_cmd = m_connection.CreateCommand();
                    sqlite_cmd.CommandText = String.Format("SELECT * FROM '" + tables[i].ToString() + "';");
                    SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        string key = sqlite_datareader.GetString(0);
                        string compareKey = key.Substring(0, uncompletedKey.Length);
                        if (uncompletedKey == compareKey)
                        {
                            detail = new KeyDetail(key);
                            detail.keypid = sqlite_datareader.GetString(1);
                            detail.eid = sqlite_datareader.GetString(2);
                            detail.aid = sqlite_datareader.GetString(3);
                            detail.edi = sqlite_datareader.GetString(4);
                            detail.sub = sqlite_datareader.GetString(5);
                            detail.lit = sqlite_datareader.GetString(6);
                            detail.lic = sqlite_datareader.GetString(7);
                            detail.cid = sqlite_datareader.GetString(8);

                            detail.prd = tables[i].ToString();

                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Check uncompleted key exist fail");
            }

            this.CloseDB();

            return detail;
        }
        public void AddUnsupportedToDB(string unSupportedKey)
        {
            this.ConnectToDB();

            string tableName = "Unsupported Key";
            KeyDetail detail = new KeyDetail(unSupportedKey);
            detail.prd = tableName;
            detail.time = Utils.GetCurrentTime();

            //check table name exist
            SQLiteCommand table_cmd = m_connection.CreateCommand();

            table_cmd.CommandText = @" CREATE TABLE IF NOT EXISTS '" + tableName + @"' (
                                        Product_Key text PRIMARY KEY,
                                        Product_ID text,
                                        Advanced_PID text,
                                        Activation_ID text,
                                        Edition_Type text,
                                        Sub_Type text,
                                        Key_Type text,
                                        Eula text,
                                        Crypto_ID text,
                                        Activation_Count integer,
                                        Error_Code text,
                                        Time text
                                    ); ";
            table_cmd.ExecuteNonQuery();

            //add key to table
            SQLiteCommand sqlite_cmd = m_connection.CreateCommand();
            sqlite_cmd.CommandText = String.Format(@"INSERT INTO '" + tableName + @"' (Product_Key, Product_ID, Advanced_PID, Activation_ID,
                                            Edition_Type, Sub_Type, Key_Type, Eula, Crypto_ID, Activation_Count, Error_Code, Time) 
                                            VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}');",
                                       detail.key, detail.keypid, detail.eid, detail.aid,
                                       detail.edi, detail.sub, detail.lit, detail.lic, detail.cid,
                                       detail.activationCount, detail.errorCode, detail.time);
            sqlite_cmd.ExecuteNonQuery();

            this.CloseDB();
        }
    }
}
