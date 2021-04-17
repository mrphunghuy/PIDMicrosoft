using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;
using System.Threading;

namespace PIDMicrosoft
{
    class PIDChecker
    {
        [DllImport("pidgenx.dll", EntryPoint = "PidGenX", CharSet = CharSet.Auto)]
        static extern int PidGenX(string ProductKey, string PkeyPath, string MSPID, int UnknownUsage, IntPtr ProductID, IntPtr DigitalProductID, IntPtr DigitalProductID4);

        private static List<string> pkeyConfigList = GetPKeyConfigList();
        private static string GetProductDescription(string pkey, string aid, string edi)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pkey);
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(doc.GetElementsByTagName("tm:infoBin")[0].InnerText)))
            {
                doc.Load(stream);
                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("pkc", "http://www.microsoft.com/DRM/PKEY/Configuration/2.0");
                try
                {
                    XmlNode node = doc.SelectSingleNode("/pkc:ProductKeyConfiguration/pkc:Configurations/pkc:Configuration[pkc:ActConfigId='" + aid + "']", ns);
                    if (node == null)
                    {
                        node = doc.SelectSingleNode("/pkc:ProductKeyConfiguration/pkc:Configurations/pkc:Configuration[pkc:ActConfigId='" + aid.ToUpper() + "']", ns);
                    }
                    if (node != null && node.HasChildNodes)
                    {
                        if (node.ChildNodes[2].InnerText.Contains(edi))
                        {
                            return node.ChildNodes[3].InnerText;
                        }
                        return "Not Found";
                    }
                    return "Not Found";
                }
                catch (Exception)
                {
                    return "Not Found";
                }
            }
        }
        static string GetString(byte[] bytes, int index)
        {
            int n = index;
            while (!(bytes[n] == 0 && bytes[n + 1] == 0)) n++;
            return Encoding.ASCII.GetString(bytes, index, n - index).Replace("\0", "");
        }
        static List<string> GetPKeyConfigList()
        {
            List<string> pkeyConfigList = new List<string>();
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.Load("PKeyConfig\\PkeyData.xml"); // Load the XML document from the specified file

            XmlNodeList configNodeList = xmlDoc.GetElementsByTagName("configType");
            for (int i = 0; i < configNodeList.Count; i++)
            {
                pkeyConfigList.Add("PKeyConfig\\" + configNodeList[i].Attributes["configPath"].Value);
            }

            return pkeyConfigList;
        }
        public static KeyDetail Check(string productKey)
        {
            KeyDetail detail = null;

            byte[] gpid = new byte[0x32];
            byte[] opid = new byte[0xA4];
            byte[] npid = new byte[0x04F8];

            IntPtr PID = Marshal.AllocHGlobal(0x32);
            IntPtr DPID = Marshal.AllocHGlobal(0xA4);
            IntPtr DPID4 = Marshal.AllocHGlobal(0x04F8);

            string MSPID = "00000";

            gpid[0] = 0x32;
            opid[0] = 0xA4;
            npid[0] = 0xF8;
            npid[1] = 0x04;

            Marshal.Copy(gpid, 0, PID, 0x32);
            Marshal.Copy(opid, 0, DPID, 0xA4);
            Marshal.Copy(npid, 0, DPID4, 0x04F8);

            int RetID = -1;
            string pKeyConfig = "";

            for (int i = 0; i < pkeyConfigList.Count; i++)
            {
                pKeyConfig = pkeyConfigList[i];
                RetID = PidGenX(productKey, pKeyConfig, MSPID, 0, PID, DPID, DPID4);
                if (RetID == 0)
                {
                    detail = new KeyDetail(productKey);
                    Marshal.Copy(PID, gpid, 0, gpid.Length);
                    Marshal.Copy(DPID4, npid, 0, npid.Length);
                    detail.keypid = GetString(gpid, 0x0000);
                    detail.eid = GetString(npid, 0x0008);
                    detail.aid = GetString(npid, 0x0088);
                    detail.edi = GetString(npid, 0x0118);
                    detail.sub = GetString(npid, 0x0378);
                    detail.lit = GetString(npid, 0x03F8);
                    detail.lic = GetString(npid, 0x0478);
                    // Fix for 4/5 digit Win 8 CryptoId, Win 7 (3 digit) and Office (2 or 3 digit) are prefixed with zeros which are stripped below
                    detail.cid = Convert.ToInt32(detail.eid.Substring(6, 5)).ToString(CultureInfo.InvariantCulture);
                    string prd = GetProductDescription(pKeyConfig, "{" + detail.aid + "}", detail.edi);

                    if (prd.StartsWith("RTM_"))
                    {
                        prd = "Office14" + prd.Remove(0, 3);
                    }
                    detail.prd = prd;

                    break;
                }
            }

            Marshal.FreeHGlobal(PID);
            Marshal.FreeHGlobal(DPID);
            Marshal.FreeHGlobal(DPID4);
            //FreeLibrary(dllHandle);

            return detail;
        }
    }
}
