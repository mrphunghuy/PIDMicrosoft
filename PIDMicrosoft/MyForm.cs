using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace PIDMicrosoft
{
    partial class MyForm : Form
    {
        const string TOOL_VERSION = "1.3.6";
        bool isPIDRunning = false;
        bool isPIDCanceling = false;

        bool isKeyRefreshing = false;
        bool isKeyRefreshCanceling = false;

        int lineIndex = 0;
        List<string> validLineList = new List<string>();

        KeyChecker keyChecker = new KeyChecker();
        KeyDatabase keyDatabase = new KeyDatabase();

        int doneLineCount = 0;

        List<string> result = new List<string>();
        bool isUpdatingResult = false;

        public static string m_email = "";
        public static string m_password = "";
        public MyForm()
        {
            InitializeComponent();

            this.Text = "PID Microsoft v" + TOOL_VERSION + " - KichHoat24H.Com";

            this.splitContainer1.Panel2.Hide();

            this.pidCheckLabel.Text = "Progress: 0/0 | Time: 0.000 (s)";
            this.cidTimeLabel.Text = "Time: 0.000 (s)";

            this.cidCommandType.Items.Add("All Windows");
            this.cidCommandType.Items.Add("All Office");
            this.cidCommandType.Items.Add("Office 2010");
            this.cidCommandType.Items.Add("Office 2013");
            this.cidCommandType.Items.Add("Office 2016/2019");
            this.cidCommandType.SelectedIndex = 0;
            this.loginStatusLabel.Hide();

            this.threadNumComboBox.Items.Add("1 Thread");
            this.threadNumComboBox.Items.Add("2 Threads");
            this.threadNumComboBox.SelectedIndex = 1;

            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Remove(this.tabPage3);
        }
        private void CheckForUpdate()
        {
            string latestVersion = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string res = reader.ReadToEnd();
                    string[] subres = res.Split('\n');
                    if(subres[0] == "true")
                    {
                        latestVersion = subres[1];
                    }
                }
            }
            catch (Exception e){}

            if(latestVersion != "" && latestVersion != TOOL_VERSION)
            {
                if (MessageBox.Show("New update version " + latestVersion + " is available! Do you want to download it now ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("");
                }
            }
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            keyDatabase.InitDB();
            UpdateKeyMS();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void copyRawCIDButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.cidOutputTextBox.Text);
                string backupText = this.cidOutputTextBox.Text;
                this.cidOutputTextBox.Text = "Copied!";
                Application.DoEvents();
                Thread.Sleep(500);
                this.cidOutputTextBox.Text = backupText;
            }
            catch(Exception e1) { };
        }

        private void MyForm_Closed(object sender, FormClosedEventArgs e)
        {
        }

        private void MyForm_Shown(object sender, EventArgs e)
        {
            Utils.loadAccount(this.emailTextBox, this.passwordTextBox);
            CheckForUpdate();
        }

        private void GetCID_Click(object sender, EventArgs e)
        {
            string iid = this.iidInputTextBox.Text;
            string convertedIID = "";
            foreach(char i in iid)
            {
                if(i >= '0' && i <='9')
                {
                    convertedIID += i;
                }
            }

            this.iidInputTextBox.Text = convertedIID;

            if(convertedIID == "")
            {
                this.cidOutputTextBox.Text = "IID must by not empty!";
                return;
            }

            this.iidInputTextBox.Enabled = false;
            this.getCIDButton.Enabled = false;
            this.getCIDButton.Text = "Getting CID...";
            this.cidDashOutputTextBox.Text = "";
            this.cidOutputTextBox.Text = "";
            this.cidCommandOutputTextbox.Text = "";

            this.cidTimeLabel.Enabled = true;
            Application.DoEvents();

            string live_get = "false";
            if(this.checkBox1.Checked)
            {
                live_get = "true";
            }

            string cid = "";

            Thread t = new Thread(() =>
            {
                cid = Utils.GetCID(convertedIID, live_get);
            });
            t.Start();

            DateTime startTime = DateTime.Now;

            while(t.IsAlive)
            {
                this.UpdateCIDTimeLabel(startTime);
                Thread.Sleep(1);
            }

            this.iidInputTextBox.Enabled = true;
            this.getCIDButton.Enabled = true;
            this.getCIDButton.Text = "Get CID";

            if (cid == "")
            {
                this.cidOutputTextBox.Text = "Connect to server fail!";
                return;
            }

            this.cidOutputTextBox.Text = cid;
            this.updateCidDashOutput(cid);
            this.UpdateCIDComandOutput(null, null);
        }
        private void UpdateCIDTimeLabel(DateTime startGetCIDTime)
        {
            var deltaTime = DateTime.Now - startGetCIDTime;
            var ms = deltaTime.TotalSeconds;

            this.cidTimeLabel.Text = "Time: " + ms.ToString("0.000") + " (s)";
            Application.DoEvents();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCIDComandOutput(object sender, EventArgs e)
        {
            this.cidCommandOutputTextbox.Text = "";
            string cid = this.cidOutputTextBox.Text;
            Application.DoEvents();
            if(!Utils.isIDValid(cid))
            {
                return;
            }

            Utils.generateCommand(this.cidCommandOutputTextbox, this.cidCommandType.Text, cid);
        }

        private void CopyCIDCommand(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.cidCommandOutputTextbox.Text);
                string backupText = this.cidCommandOutputTextbox.Text;
                this.cidCommandOutputTextbox.Text = "Copied!";
                Application.DoEvents();
                Thread.Sleep(500);
                this.cidCommandOutputTextbox.Text = backupText;
            }
            catch (Exception e1) { };
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            string email = this.emailTextBox.Text;
            string password = this.passwordTextBox.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("User ID and Password must be not empty!", "Error");
                return;
            }

            this.loginStatusLabel.Show();
            this.loginStatusLabel.Text = "Logging in...";
            Application.DoEvents();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("");

                var postData = "email=" + Uri.EscapeDataString(email);
                postData += "&password=" + Uri.EscapeDataString(password);
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string res = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string[] subRes = res.Split('\n');
                if (subRes[0] == "true")
                {
                    this.splitContainer1.Panel1.Hide();
                    this.splitContainer1.Panel2.Show();
                    this.loginStatusLabel.Hide();

                    MyForm.m_email = email;
                    MyForm.m_password = password;

                    if(this.rememberAccountCheckbox.Checked)
                    {
                        Utils.saveAccount(email, password);
                    }

                    this.userEmailLabel.Text = subRes[1]; //email
                    this.accountTypeLabel.Text = subRes[2];
                    this.expiredDateLabel.Text = subRes[3];

                    this.UpdateCounters();

                    this.SuspendLayout();
                    this.tabControl1.SuspendLayout();
                    this.tabControl1.TabPages.Insert(0,this.tabPage1);
                    this.tabControl1.TabPages.Insert(1,this.tabPage2);
                    this.tabControl1.TabPages.Insert(2,this.tabPage3);
                    this.tabControl1.PerformLayout();
                    this.PerformLayout();
                }
                else if(subRes[0] == "false")
                {
                    this.loginStatusLabel.Text = subRes[1];
                }
                else
                {
                    this.loginStatusLabel.Text = "Connect to server fail!";
                }
            }
            catch (Exception e1) 
            {
                this.loginStatusLabel.Text = "Connect to server fail!";
            };
        }

        private void UpdateCounters()
        {
            if(m_email == "" || m_password == "")
            {
                return;
            }

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("");

                var postData = "email=" + Uri.EscapeDataString(m_email);
                postData += "&password=" + Uri.EscapeDataString(m_password);
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string res = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string[] subRes = res.Split('\n');
                if (subRes[0] == "true")
                {
                    this.label9.Text = subRes[1] + "/" + subRes[2];
                    this.label12.Text = subRes[3] + "/" + subRes[4];
                }
            }
            catch (Exception e1){};
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("");
        }

        private void DonateButtonClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("");
        }

        private void LogoutButtonClick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.PerformLayout();

            this.splitContainer1.Panel1.Show();
            this.splitContainer1.Panel2.Hide();

            this.PerformLayout();
        }

        public static void CheckKeyOnThread(Object obj)
        {
            MyForm form = (MyForm)obj;

            if(form.lineIndex >= form.validLineList.Count)
            {
                return;
            }

            string productKey = form.validLineList[form.lineIndex];

            form.lineIndex++;

            List<string> res = form.keyChecker.FindKeysInLine(productKey, CheckMode.ALL_DATA, form.keyDatabase);

            while (form.isUpdatingResult) { };

            form.result.AddRange(res);

            form.doneLineCount++;

            if(form.isPIDCanceling)
            {
                return;
            }

            CheckKeyOnThread(form);
        }

        private void OnCheckButtonClick(object sender, EventArgs e)
        {
            if(isPIDCanceling)
            {
                return;
            }

            if(isPIDRunning)
            {
                this.checkButton.Text = "Canceling..";
                this.checkButton.Enabled = false;
                isPIDCanceling = true;

                return;
            }

            string inputText = this.pidInputTextbox.Text;
            inputText = inputText.Replace(" ", "");
            inputText = inputText.Replace("\t", "");
            inputText = inputText.Replace("\r", "");
            string[] lines = inputText.Split('\n');
            this.validLineList = new List<string>();
            foreach(string l in lines)
            {
                if(l != "")
                {
                    validLineList.Add(l);
                }
            }

            if(validLineList.Count == 0)
            {
                this.pidOutputTextbox.Text = "Key must be not empty!";
                return;
            }

            isPIDRunning = true;

            this.checkButton.Text = "Cancel";
            this.pidInputTextbox.Enabled = false;
            this.threadNumComboBox.Enabled = false;
            this.pidOutputTextbox.Text = "";
            Application.DoEvents();

            DateTime startTime = DateTime.Now;
            this.lineIndex = 0;
            this.doneLineCount = 0;

            int threadNum = this.threadNumComboBox.SelectedIndex + 1;

            int keyNum = validLineList.Count;

            List<Thread> tList = new List<Thread>();

            for (int i = 0; i < threadNum; i++)
            {
                if (i >= keyNum)
                {
                    break;
                }

                Thread t = new Thread(new ParameterizedThreadStart(CheckKeyOnThread));
                t.Start(this);

                tList.Add(t);

                Thread.Sleep(10);
            }

            while (true)
            {
                int doneThreadNum = 0;
                for (int i = 0; i < tList.Count; i++)
                {
                    if (!tList[i].IsAlive)
                    {
                        doneThreadNum++;
                    }
                }

                this.UpdatePIDTimeLabel(startTime, this.doneLineCount, validLineList.Count);

                while (this.isUpdatingResult) { };

                if (this.result.Count > 0)
                {
                    this.isUpdatingResult = true;

                    //
                    for (int i = 0; i < this.result.Count; i++)
                    {
                        this.pidOutputTextbox.AppendText(this.result[i].ToString());
                    }

                    this.result.Clear();

                    this.UpdateKeyMS();

                    this.isUpdatingResult = false;
                }

                if (doneThreadNum == tList.Count)
                {
                    break;
                }

                Thread.Sleep(1);
            }

            this.UpdatePIDTimeLabel(startTime, this.doneLineCount, validLineList.Count);

            this.checkButton.Text = "Check Online";
            this.checkButton.Enabled = true;
            this.threadNumComboBox.Enabled = true;
            this.pidInputTextbox.Enabled = true;

            isPIDRunning = false;
            isPIDCanceling = false;
        }
        private void UpdatePIDTimeLabel(DateTime startGetCIDTime, int lIndex, int totalLineNum)
        {
            var deltaTime = DateTime.Now - startGetCIDTime;
            var ms = deltaTime.TotalSeconds;

            this.pidCheckLabel.Text = "Progress: " + lIndex.ToString() + "/" + totalLineNum.ToString() + " | Time: " + ms.ToString("0.000") + " (s)";
            Application.DoEvents();
        }
        private void UpdateKeyMS()
        {
            ArrayList tables = keyDatabase.GetTables();
            if(tables.Count == 0)
            {
                return;
            }

            string currentKeyType = "";

            if (this.keyTypeComboBox.SelectedItem == null)//firstTime
            {
                currentKeyType = tables[tables.Count / 2].ToString();
            }
            else
            {
                currentKeyType = this.keyTypeComboBox.SelectedItem.ToString();
            }

            this.keyTypeComboBox.Items.Clear();
            foreach (object i in tables)
            {
                this.keyTypeComboBox.Items.Add(i.ToString());
            }
            this.keyTypeComboBox.SelectedItem = currentKeyType;
        }

        private void KeyTypeSelectedChanged(object sender, EventArgs e)
        {
            if(this.keyTypeComboBox.Items.Count <= 0)
            {
                return;
            }

            string keyType = this.keyTypeComboBox.SelectedItem.ToString();
            ArrayList keyList = keyDatabase.GetAllKeyFromTable(keyType);

            this.keyDataGridView.SuspendLayout();

            this.keyDataGridView.Rows.Clear();

            int idx = 1;

            string filterString = this.searchKeysTextbox.Text.ToUpper();

            if (this.showDeadKeysCheckbox.Checked)
            {
                foreach (KeyDetail dt in keyList)
                {
                    if (dt.key.ToUpper().Contains(filterString) || dt.sub.ToUpper().Contains(filterString)
                    || dt.errorCode.ToUpper().Contains(filterString) || dt.time.ToUpper().Contains(filterString)
                    || dt.activationCount.ToString().ToUpper().Contains(filterString))
                    {
                        this.keyDataGridView.Rows.Add(idx.ToString(), dt.key, dt.sub, dt.activationCount, dt.errorCode, dt.time);
                        idx++;
                    }
                }
            }
            else
            {
                foreach (KeyDetail dt in keyList)
                {
                    if (dt.errorCode != "0xC004C003" && dt.errorCode != "0xC004C060" && dt.errorCode != "0xC004C004" && dt.errorCode != "Key Blocked") //key blocked or no remaining
                    {
                        if (dt.key.ToUpper().Contains(filterString) || dt.sub.ToUpper().Contains(filterString)
                        || dt.errorCode.ToUpper().Contains(filterString) || dt.time.ToUpper().Contains(filterString)
                        || dt.activationCount.ToString().ToUpper().Contains(filterString))
                        {
                            this.keyDataGridView.Rows.Add(idx.ToString(), dt.key, dt.sub, dt.activationCount, dt.errorCode, dt.time);
                            idx++;
                        }
                    }
                }
            }

            this.keyDataGridView.PerformLayout();
        }

        private void updateCidDashOutput(string cid)
        {
            if(!Utils.isIDValid(cid))
            {
                return;
            }

            string dashText = "";

            int digitNum = cid.Length / 8;
            for(int i=0;i<8;i++)
            {
                string pice = cid.Substring(i * digitNum, digitNum);
                dashText += pice;
                if (i < 7)
                {
                    dashText += "-";
                }
            }

            this.cidDashOutputTextBox.Text = dashText;
        }
        private void cidDashOutputCopyButtonClick(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.cidDashOutputTextBox.Text);
                string backupText = this.cidDashOutputTextBox.Text;
                this.cidDashOutputTextBox.Text = "Copied!";
                Application.DoEvents();
                Thread.Sleep(500);
                this.cidDashOutputTextBox.Text = backupText;
            }
            catch (Exception e1) { };
        }

        private void keyTableMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.keyDataGridView.Rows.Count > 0)
            {
                ContextMenu cm = new ContextMenu();
                this.keyDataGridView.ContextMenu = cm;

                MenuItem refreshMenu = null;
                if(!isKeyRefreshing)
                {
                    refreshMenu = new MenuItem("&Refresh", new System.EventHandler(this.keyTableRefreshClick));
                }
                else if(!isKeyRefreshCanceling)
                {
                    refreshMenu = new MenuItem("&Cancel Refresh", new System.EventHandler(this.keyTableRefreshClick));
                }
                else
                {
                    refreshMenu = new MenuItem("&Canceling Refresh...", new System.EventHandler(this.keyTableRefreshClick));
                    refreshMenu.Enabled = false;
                }

                cm.MenuItems.Add(refreshMenu);

                var separator1 = new MenuItem("-");
                cm.MenuItems.Add(separator1);
                cm.MenuItems.Add(new MenuItem("&Copy", new System.EventHandler(this.keyTableCopyClick)));
                var separator2 = new MenuItem("-");
                cm.MenuItems.Add(separator2);
                cm.MenuItems.Add(new MenuItem("&Delete", new System.EventHandler(this.keyTableDeleteClick)));

                cm.Show(this.keyDataGridView, new Point(e.X, e.Y));
            }
        }

        private void keyTableCopyClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.keyDataGridView.GetClipboardContent());
        }

        private void keyTableDeleteClick(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection selectedCells = this.keyDataGridView.SelectedCells;

            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();

            for (int i = 0; i < selectedCells.Count; i++)
            {
                selectedRows.Add(this.keyDataGridView.Rows[selectedCells[i].RowIndex]);
            }

            if (selectedRows.Count == 0)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this, "This will delete selected keys permanently. Are you sure to continue?", "Delete Product Keys", MessageBoxButtons.YesNo,MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            string tableName = this.keyTypeComboBox.SelectedItem.ToString();

            foreach (var r in selectedRows)
            {
                string key = r.Cells[1].Value.ToString();
                keyDatabase.DeleteKeyInDB(tableName, key);
                this.keyDataGridView.Rows.Remove(r);
            }

            if(this.keyDataGridView.Rows.Count == 0)
            {
                keyDatabase.DeleteTableInDB(tableName);
                this.keyTypeComboBox.Items.RemoveAt(this.keyTypeComboBox.SelectedIndex);
                this.UpdateKeyMS();
            }
        }

        private void keyTableRefreshClick(object sender, EventArgs e)
        {
            if (isKeyRefreshCanceling)
            {
                return;
            }

            if (isKeyRefreshing)
            {
                isKeyRefreshCanceling = true;

                return;
            }

            DataGridViewSelectedCellCollection selectedCells = this.keyDataGridView.SelectedCells;

            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();

            for (int i = 0; i < selectedCells.Count; i++)
            {
                selectedRows.Add(this.keyDataGridView.Rows[selectedCells[i].RowIndex]);
            }

            if (selectedRows.Count == 0)
            {
                return;
            }

            isKeyRefreshing = true;

            string tableName = this.keyTypeComboBox.SelectedItem.ToString();

            foreach (var r in selectedRows.Reverse())
            {
                string key = r.Cells[1].Value.ToString();

                r.Cells[3].Value = "Updating..";
                r.Cells[4].Value = "Updating..";
                r.Cells[5].Value = "Updating..";

                Thread t = new Thread(() =>
                {
                    keyChecker.Check(key, CheckMode.ALL_DATA, keyDatabase);
                });
                t.Start();

                while (t.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }

                KeyDetail detail = keyDatabase.GetKeyDetail(key);
                if(detail != null)
                {
                    r.Cells[3].Value = detail.activationCount.ToString();
                    r.Cells[4].Value = detail.errorCode;
                    r.Cells[5].Value = detail.time;

                    Application.DoEvents();
                }

                if(isKeyRefreshCanceling)
                {
                    break;
                }
            }

            isKeyRefreshing = false;
            isKeyRefreshCanceling = false;
        }

        private void showDeadKeys_checkedChanged(object sender, EventArgs e)
        {
            KeyTypeSelectedChanged(null, null);
        }

        private void searchKeys_textChanged(object sender, EventArgs e)
        {
            KeyTypeSelectedChanged(null, null);
        }

        private void searchTextbox_clicked(object sender, EventArgs e)
        {
            this.searchKeysTextbox.SelectAll();
        }

        private void searchTextbox_doubleClicked(object sender, EventArgs e)
        {
            this.searchKeysTextbox.SelectAll();
        }

        private void pidCheckTextboxInput_Clicked(object sender, EventArgs e)
        {
        }

        private void pidCheckTextboxInput_DoubleClicked(object sender, EventArgs e)
        {
        }

        private void cidInputTextbox_Clicked(object sender, EventArgs e)
        {

        }

        private void cidInputTextbox_DoubleClicked(object sender, EventArgs e)
        {
        }
        private void OnAccountFocused(object sender, EventArgs e)
        {
        }

        private void OnAccountTabShown(object sender, TabControlEventArgs e)
        {
        }

        private void OnAccountTabSelected(object sender, EventArgs e)
        {
            this.UpdateCounters();
        }

        private void iidInputTextChanged(object sender, EventArgs e)
        {
            string oldText = this.iidInputTextBox.Text;
            this.iidInputTextBox.Text = oldText.Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");
        }
    }
}
