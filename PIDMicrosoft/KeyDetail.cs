
namespace PIDMicrosoft
{
    class KeyDetail
    {
        public string key = "";
        public string keypid = "";
        public string eid = "";
        public string aid = "";
        public string edi = "";
        public string sub = "";
        public string lit = "";
        public string lic = "";
        public string cid = "";
        public string prd = "";
        public int activationCount = -1;
        public string errorCode = "";
        public string time = "";
        public KeyDetail(string productKey)
        {
            key = productKey;
        }
    }
}
