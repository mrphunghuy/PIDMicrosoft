using System;
using System.Text;
using System.Net;
using System.Xml;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Generic;

namespace PIDMicrosoft
{
    enum CheckMode
    {
        ALL_DATA,
        PID_CHECK
    };

    class KeyChecker
    {
        public string GetErrorCodeOnServer(string keyType, string key, bool isVLKey = false)
        {
            string is_vl = "false";
            if (isVLKey)
            {
                is_vl = "true";
            }

            string errorCode = "";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("");

                var postData = "email=" + Uri.EscapeDataString(MyForm.m_email);
                postData += "&password=" + Uri.EscapeDataString(MyForm.m_password);
                postData += "&key_type=" + Uri.EscapeDataString(keyType);
                postData += "&key=" + Uri.EscapeDataString(key);
                postData += "&is_vl=" + Uri.EscapeDataString(is_vl);
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
                if(subRes[0] == "true")
                {
                    errorCode = subRes[1];
                }
            }
            catch (Exception e1) {
            };

            if (errorCode.Contains("Try Again Later"))
            {
                errorCode = "";
            }

            return errorCode;
        }

        public List<string> FindKeysInLine(string content, CheckMode checkMode, KeyDatabase keyDatabase)
        {
            List<string> result = new List<string>();

            return result;
        }
        public string Check(string key, CheckMode checkMode, KeyDatabase keyDatabase)
        {
            key = key.ToUpper();

            string result = "";

            for (int j = 0; j < key.Length; j++)
            {
                char chr = key[j];
                if (!(chr == '-' || (chr >= '0' && chr <= '9') || (chr >= 'A' && chr <= 'Z')))
                {
                    return result;
                }
            }

            KeyDetail detail = keyDatabase.GetKeyDetail(key);

            bool isKeyExistOnDB = true;
            if(detail == null) //Key is not exist on DB
            {
                detail = PIDChecker.Check(key);
                isKeyExistOnDB = false;
            }

            if (detail == null || detail.prd.Contains("Unsupported")) //Key is invalid
            {
//                 result += "Key: " + key + "\n";
//                 result += "Error: Key is invalid or not supported\n\n";
                return result;
            }

            bool isActivationCountUpdated = false;
            bool isErrorCodeUpdated = false;
            bool isGetErrorCodeFail = false;

            if (!(isKeyExistOnDB && detail.activationCount < 0))
            {
                detail.activationCount = GetRemainingActivations(detail.eid);
                isActivationCountUpdated = true;
            }

            if (detail.activationCount <= 0)
            {
                bool isNeedGetErrorCode = true;

                bool isVLKey = false;
                if (detail.activationCount == 0)
                {
                    isVLKey = true;
                }

                if (detail.errorCode == "0xC004C003" || detail.errorCode == "0xC004C060" || detail.errorCode == "0xC004C004" || detail.errorCode == "Key Blocked") //key blocked or no remaining
                {
                    isNeedGetErrorCode = false;
                }
                else
                {
                    if(isKeyExistOnDB && detail.time != "")
                    {
                        var now = DateTime.Now;
                        var lastTime = Utils.ConvertStringToTime(detail.time);
                        var dt = now - lastTime;
                        int timeToRecheck = 4;
                        if(detail.prd.Contains("Windows 7") || detail.prd.Contains("Office14"))
                        {
                            timeToRecheck = 10;
                        }

                        if(dt.TotalMinutes <= timeToRecheck)
                        {
                            isNeedGetErrorCode = false;
                        }
                    }
                }

                if (isNeedGetErrorCode && checkMode == CheckMode.ALL_DATA)
                {
                    string errorCode = this.GetErrorCodeOnServer(detail.prd, detail.key, isVLKey);
                    if (errorCode == "")
                    {
                        isGetErrorCodeFail = true;
                    }
                    else
                    {
                        detail.errorCode = errorCode;
                        isErrorCodeUpdated = true;
                    }
                }
            }

            if (!isKeyExistOnDB)
            {
                detail.time = Utils.GetCurrentTime();


                keyDatabase.AddKeyToDB(detail);
            }
            else if ((isErrorCodeUpdated || isActivationCountUpdated) && !isGetErrorCodeFail)
            {
                detail.time = Utils.GetCurrentTime();

                keyDatabase.UpdateKeyInDB(detail);
            }
            else if(detail.time == "")
            {
                detail.time = Utils.GetCurrentTime();
            }

            result += "Key: " + key + "\r\n";
            result += "Description: " + detail.prd + "\r\n";
            result += "Sub Type: " + detail.sub + "\r\n";
            if(detail.activationCount >=0) result += "Activation Count: " + detail.activationCount.ToString() + "\r\n";
            if(detail.activationCount <= 0 && checkMode == CheckMode.ALL_DATA)
            {
                if (isGetErrorCodeFail)
                {
                    result += "Error Code: Server busy, please try again later\r\n";
                }
                else
                {
                    result += "Error Code: " + detail.errorCode + "\r\n";
                }
            }
            result += "Time: " + detail.time + "\r\n\r\n";

            return result;
        }
        public static int GetRemainingActivations(string pid)
        {
            // Microsoft's PRIVATE KEY for HMAC-SHA256 encoding
            byte[] bPrivateKey = new byte[]
            {
            0xfe, 0x31, 0x98, 0x75, 0xfb, 0x48, 0x84, 0x86, 0x9c, 0xf3, 0xf1, 0xce, 0x99, 0xa8, 0x90, 0x64,
            0xab, 0x57, 0x1f, 0xca, 0x47, 0x04, 0x50, 0x58, 0x30, 0x24, 0xe2, 0x14, 0x62, 0x87, 0x79, 0xa0
            };

            // XML Namespace
            const string uri = "http://www.microsoft.com/DRM/SL/BatchActivationRequest/1.0";

            // Create new XML Document
            XmlDocument xmlDoc = new XmlDocument();

            // Create Root Element
            XmlElement rootElement = xmlDoc.CreateElement("ActivationRequest", uri);
            xmlDoc.AppendChild(rootElement);

            // Create VersionNumber Element
            XmlElement versionNumber = xmlDoc.CreateElement("VersionNumber", rootElement.NamespaceURI);
            versionNumber.InnerText = "2.0";
            rootElement.AppendChild(versionNumber);

            // Create RequestType Element
            XmlElement requestType = xmlDoc.CreateElement("RequestType", rootElement.NamespaceURI);
            requestType.InnerText = "2";
            rootElement.AppendChild(requestType);

            // Create Requests Group Element
            XmlElement requestsGroupElement = xmlDoc.CreateElement("Requests", rootElement.NamespaceURI);

            // Create Request Element
            XmlElement requestElement = xmlDoc.CreateElement("Request", requestsGroupElement.NamespaceURI);

            // Add PID as Request Element
            XmlElement pidEntry = xmlDoc.CreateElement("PID", requestElement.NamespaceURI);
            pidEntry.InnerText = pid.Replace("XXXXX", "55041");
            requestElement.AppendChild(pidEntry);

            // Add Request Element to Requests Group Element
            requestsGroupElement.AppendChild(requestElement);

            // Add Requests and Request to XML Document
            rootElement.AppendChild(requestsGroupElement);

            // Get Unicode Byte Array of XML Document
            byte[] byteXml = Encoding.Unicode.GetBytes(xmlDoc.InnerXml);

            // Convert Byte Array to Base64
            string base64Xml = Convert.ToBase64String(byteXml);

            // Compute Digest of the Base 64 XML Bytes
            string digest;
            using (HMACSHA256 hmacsha256 = new HMACSHA256 { Key = bPrivateKey })
            {
                digest = Convert.ToBase64String(hmacsha256.ComputeHash(byteXml));
            }

            // Create SOAP Envelope for Web Request
            string form = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><BatchActivate xmlns=\"http://www.microsoft.com/BatchActivationService\"><request><Digest>REPLACEME1</Digest><RequestXml>REPLACEME2</RequestXml></request></BatchActivate></soap:Body></soap:Envelope>";
            form = form.Replace("REPLACEME1", digest);      // Put your Digest value (BASE64 encoded)
            form = form.Replace("REPLACEME2", base64Xml);   // Put your Base64 XML value (BASE64 encoded)
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(form);

            // Create Web Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://activation.sls.microsoft.com/BatchActivation/BatchActivation.asmx");
            webRequest.Method = "POST";
            webRequest.ContentType = "text/xml; charset=\"utf-8\"";
            webRequest.Headers.Add("SOAPAction", "http://www.microsoft.com/BatchActivationService/BatchActivate");

            // Insert SOAP Envelope into Web Request
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            // Begin Async call to Web Request
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // Suspend Thread until call is complete
            asyncResult.AsyncWaitHandle.WaitOne();

            // Get the Response from the completed Web Request
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))

            // ReSharper disable AssignNullToNotNullAttribute
            using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
            // ReSharper restore AssignNullToNotNullAttribute
            {
                soapResult = rd.ReadToEnd();
            }

            // Parse the ResponseXML from the Response
            using (XmlReader soapReader = XmlReader.Create(new StringReader(soapResult)))
            {
                // Read ResponseXML Value
                soapReader.ReadToFollowing("ResponseXml");
                string responseXml = soapReader.ReadElementContentAsString();

                // Remove HTML Entities from ResponseXML
                responseXml = responseXml.Replace("&gt;", ">");
                responseXml = responseXml.Replace("&lt;", "<");

                // Change Encoding Value in ResponseXML
                responseXml = responseXml.Replace("utf-16", "utf-8");

                // Read Fixed ResponseXML Value as XML
                using (XmlReader reader = XmlReader.Create(new StringReader(responseXml)))
                {
                    try
                    {
                        reader.ReadToFollowing("ActivationRemaining");
                        string count = reader.ReadElementContentAsString();

                        if (Convert.ToInt32(count) < 0)
                        {
                            reader.ReadToFollowing("ErrorCode");
                            string error = reader.ReadElementContentAsString();

                            if (error == "0x67")
                            {
                                //return "0 (Blocked)";
                                return 0;
                            }
                        }
                        return Convert.ToInt32(count);
                    }
                    catch(Exception e){
                        return -1;
                    }
                }
            }
        }
    }
}
