using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace PIDMicrosoft
{
    class Utils
    {
        public static string GetCID(string iid, string live_get)
        {
            string cid = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("");

                var postData = "email=" + Uri.EscapeDataString(MyForm.m_email);
                postData += "&password=" + Uri.EscapeDataString(MyForm.m_password);
                postData += "&iid=" + Uri.EscapeDataString(iid);
                postData += "&live_get=" + Uri.EscapeDataString(live_get);
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
                    cid = subRes[1];
                }
                //Console.WriteLine(res);
            }
            catch (Exception e1) { };

            return cid;
        }
        public static bool isIDValid(string id)
        {
            if(id == "")
            {
                return false;
            }

            foreach(char i in id)
            {
                if(i <'0' || i >'9')
                {
                    return false;
                }
            }

            return true;
        }

        public static string GetCurrentTime()
        {
            var now = DateTime.UtcNow;
            return now.ToLocalTime().ToString("HH:mm:ss dd/MM/yyyy") + " (GMT+7)";
        }

        public static DateTime ConvertStringToTime(string inTime)
        {
            DateTime dt = DateTime.Today.AddYears(-1);
            try
            {
                string newInTime = inTime.Replace(" (GMT+7)", "");
                dt = DateTime.ParseExact(newInTime, "HH:mm:ss dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e) { }

            return dt;
        }

        public static int GetCurrentHour()
        {
            var now = DateTime.UtcNow;
            return now.ToLocalTime().Hour;
        }

        static readonly string PasswordHash = "";
        static readonly string SaltKey = "";
        static readonly string VIKey = "";
        public static string Encrypt(string plainText)
        {
            
        }

        public static string Decrypt(string encryptedText)
        {
            
        }

        static readonly string authenticationFileName = "login_token.dat";
        public static void saveAccount(string username, string password)
        {
            
        }

        public static void loadAccount(TextBox userTextbox, TextBox passTextbox)
        {

        }

        public static void generateCommand(TextBox commandTextBox, string optionVersion, string cid)
        {
            if (cid == "")
            {
                return;
            }

            if (optionVersion == "All Windows")
            {
                commandTextBox.AppendText("set CID=" + cid + "\r\ncscript slmgr.vbs /atp %CID%\r\ncscript slmgr.vbs /ato\r\n");
                commandTextBox.AppendText("for /f \"tokens=2,3,4,5,6 usebackq delims=:/ \" %%a in ('%date% %time%') do echo %%c-%%a-%%b %%d%%e\r\n");
                commandTextBox.AppendText("echo DATE: %date% >status.txt\r\n");
                commandTextBox.AppendText("echo TIME: %time% >>status.txt\r\n");
                commandTextBox.AppendText("for /f \"tokens=3\" %b in ('cscript.exe %windir%\\system32\\slmgr.vbs /dti') do set IID=%b\r\n");
                commandTextBox.AppendText("echo IID: %IID% >>status.txt\r\n");
                commandTextBox.AppendText("echo CID: " + cid + " >>status.txt\r\n");
                commandTextBox.AppendText("cscript slmgr.vbs /dli >>status.txt\r\n");
                commandTextBox.AppendText("cscript slmgr.vbs /xpr >>status.txt\r\n");
                commandTextBox.AppendText("start status.txt\r\n");
            }
            else if (optionVersion =="All Office")
            {
                commandTextBox.AppendText("for %a in (4,5,6) do (if exist \"%ProgramFiles%\\Microsoft Office\\Office1%a\\ospp.vbs\" (cd /d \"%ProgramFiles%\\Microsoft Office\\Office1%a\")\r\n");
                commandTextBox.AppendText("if exist \"%ProgramFiles% (x86)\\Microsoft Office\\Office1%a\\ospp.vbs\" (cd /d \"%ProgramFiles% (x86)\\Microsoft Office\\Office1%a\"))\r\n");
                commandTextBox.AppendText("set CID=" + cid + "\r\n");
                commandTextBox.AppendText("cscript //nologo OSPP.VBS /actcid:%CID%\r\n");
                commandTextBox.AppendText("cscript.exe OSPP.vbs /act\r\n");
                commandTextBox.AppendText("for /f \"tokens=2,3,4,5,6 usebackq delims=:/ \" %%a in ('%date% %time%') do echo %%c-%%a-%%b %%d%%e\r\n");
                commandTextBox.AppendText("echo DATE: %date% >status.txt\r\n");
                commandTextBox.AppendText("echo TIME: %time% >>status.txt\r\n");
                commandTextBox.AppendText("for /f \"tokens=8\" %b in ('cscript ospp.vbs /dinstid ^| findstr /b /c:\"Installation ID\"') do set IID=%b\r\n");
                commandTextBox.AppendText("echo IID: %IID%>>status.txt\r\n");
                commandTextBox.AppendText("echo CID: " + cid + ">>status.txt\r\n");
                commandTextBox.AppendText("cscript ospp.vbs /dstatus >>status.txt\r\n");
                commandTextBox.AppendText("start status.txt\r\n");
            }
            else if (optionVersion == "Office 2010")
            {
                commandTextBox.AppendText("if exist \"%ProgramFiles%\\Microsoft Office\\Office14\\ospp.vbs\" (cd /d \"%ProgramFiles%\\Microsoft Office\\Office14\")\r\n");
                commandTextBox.AppendText("if exist \"%ProgramFiles(x86)%\\Microsoft Office\\Office14\\ospp.vbs\" (cd /d \"%ProgramFiles(x86)%\\Microsoft Office\\Office14\")\r\n");
                commandTextBox.AppendText("set CID=" + cid + "\r\n");
                commandTextBox.AppendText("cscript //nologo OSPP.VBS /actcid:%CID%\r\n");
                commandTextBox.AppendText("cscript.exe OSPP.vbs /act\r\n");
                commandTextBox.AppendText("for /f \"tokens=2,3,4,5,6 usebackq delims=:/ \" %%a in ('%date% %time%') do echo %%c-%%a-%%b %%d%%e\r\n");
                commandTextBox.AppendText("echo DATE: %date% >status.txt\r\n");
                commandTextBox.AppendText("echo TIME: %time% >>status.txt\r\n");
                commandTextBox.AppendText("for /f \"tokens=8\" %b in ('cscript ospp.vbs /dinstid ^| findstr /b /c:\"Installation ID\"') do set IID=%b\r\n");
                commandTextBox.AppendText("echo IID: %IID%>>status.txt\r\n");
                commandTextBox.AppendText("echo CID:" + cid + ">>status.txt\r\n");
                commandTextBox.AppendText("cscript ospp.vbs /dstatus >>status.txt\r\n");
                commandTextBox.AppendText("start status.txt\r\n");;
            }
            else if (optionVersion == "Office 2013")
            {
                commandTextBox.AppendText("if exist \"%ProgramFiles%\\Microsoft Office\\Office15\\ospp.vbs\" (cd /d \"%ProgramFiles%\\Microsoft Office\\Office15\")\r\n");
                commandTextBox.AppendText("if exist \"%ProgramFiles(x86)%\\Microsoft Office\\Office15\\ospp.vbs\" (cd /d \"%ProgramFiles(x86)%\\Microsoft Office\\Office15\")\r\n");
                commandTextBox.AppendText("set CID=" + cid + "\r\n");
                commandTextBox.AppendText("cscript //nologo OSPP.VBS /actcid:%CID%\r\n");
                commandTextBox.AppendText("cscript.exe OSPP.vbs /act\r\n");
                commandTextBox.AppendText("for /f \"tokens=2,3,4,5,6 usebackq delims=:/ \" %%a in ('%date% %time%') do echo %%c-%%a-%%b %%d%%e\r\n");
                commandTextBox.AppendText("echo DATE: %date% >status.txt\r\n");
                commandTextBox.AppendText("echo TIME: %time% >>status.txt\r\n");
                commandTextBox.AppendText("for /f \"tokens=8\" %b in ('cscript ospp.vbs /dinstid ^| findstr /b /c:\"Installation ID\"') do set IID=%b\r\n");
                commandTextBox.AppendText("echo IID: %IID%>>status.txt\r\n");
                commandTextBox.AppendText("echo CID: " + cid + ">>status.txt\r\n");
                commandTextBox.AppendText("cscript ospp.vbs /dstatus >>status.txt\r\n");
                commandTextBox.AppendText("start status.txt\r\n");;
            }
            else if (optionVersion == "Office 2016/2019")
            {
                commandTextBox.AppendText("if exist \"%ProgramFiles%\\Microsoft Office\\Office16\\ospp.vbs\" (cd /d \"%ProgramFiles%\\Microsoft Office\\Office16\")\r\n");;
                commandTextBox.AppendText("if exist \"%ProgramFiles(x86)%\\Microsoft Office\\Office16\\ospp.vbs\" (cd /d \"%ProgramFiles(x86)%\\Microsoft Office\\Office16\")\r\n");
                commandTextBox.AppendText("set CID=" + cid + "\r\n");
                commandTextBox.AppendText("cscript //nologo OSPP.VBS /actcid:%CID%\r\n");
                commandTextBox.AppendText("cscript.exe OSPP.vbs /act\r\n");
                commandTextBox.AppendText("for /f \"tokens=2,3,4,5,6 usebackq delims=:/ \" %%a in ('%date% %time%') do echo %%c-%%a-%%b %%d%%e\r\n");
                commandTextBox.AppendText("echo DATE: %date% >status.txt\r\n");
                commandTextBox.AppendText("echo TIME: %time% >>status.txt\r\n");
                commandTextBox.AppendText("for /f \"tokens=8\" %b in ('cscript ospp.vbs /dinstid ^| findstr /b /c:\"Installation ID\"') do set IID=%b\r\n");
                commandTextBox.AppendText("echo IID: %IID%>>status.txt\r\n");
                commandTextBox.AppendText("echo CID: " + cid + ">>status.txt\r\n");
                commandTextBox.AppendText("cscript ospp.vbs /dstatus >>status.txt\r\n");
            }
        }
    }
}
