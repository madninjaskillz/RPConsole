using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace TestApp
{
    public static class Solids
    {
        public static Settings Settings=new Settings();
    }

    public class Settings
    {
        public string DaemonIp { get; set; }
        public int DaemonPort { get; set; }
    }

    public static class Helpers
    {

       public static string MakeJson(string mth, List<string> prms)
        {
            RPCModels.RPCCall call = new RPCModels.RPCCall
            {
                method = mth,
                @params = null
            };

            string s = JsonConvert.SerializeObject(call, Formatting.Indented);

            string prmstring = "";
            foreach (var t in prms)
            {
                if (!string.IsNullOrWhiteSpace(t)&&t.Contains("="))
                {
                    var ts = t.Split('=');

                    int vl = -99;
                    bool isInt = int.TryParse(ts[1], out vl);

                    prmstring = prmstring + "\"" + ts[0] + "\" : ";
                    if (isInt)
                    {
                        prmstring = prmstring + vl;
                    }
                    else
                    {
                        prmstring = prmstring + "\"" + ts[1] + "\"";
                    }
                    if (t != prms.Last())
                    {
                        prmstring = prmstring + ",\r\n";
                    }
                }
            }

            s = s.Replace(": null", ":{\r\n" + prmstring + "\r\n}\r\n");

            return s;
        }
        
        internal static string RequestServer(string ip, int port, string rpcuser, string rpcpass, string s)
        {
           string serverIp = "http://"+ip+":" + port.ToString();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(serverIp + "/json_rpc");
            
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            webRequest.ContentLength = byteArray.Length;
            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            StreamReader streamReader = null;
            try
            {
                WebResponse webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream(), true);

                string respVal = streamReader.ReadToEnd();
                string data = JsonConvert.DeserializeObject(respVal).ToString();
                return data;
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
            finally
            {
                streamReader?.Close();
            }
        }
    }

    public class RPCModels
    {
        public class RPCCall
        {
            public string jsonrpc { get; set; } = "2.0";
            public string id { get; set; } = "test";
            public string method { get; set; }
            public RPCCallParams @params { get; set; }
        }

        public class RPCCallParams
        {

        }

       
        public class RPCRoot
        {
            public string id { get; set; }
            public string jsonrpc { get; set; }
        }
    }
}
