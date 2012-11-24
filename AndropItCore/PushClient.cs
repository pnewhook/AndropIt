using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AndropIt.Core
{
    public class PushClient : IPushClient
    {
        private readonly string serverUrl = "http://10.32.110.50:8080/";
        
        public PushClient()
        {

        }

        public string SendText(string text)
        {
            string type = DetermineType(text);
            Console.WriteLine(text + " is " + type);
            JObject json = new JObject();
            json.Add(new JProperty("content", text));
            json.Add(new JProperty("device_id", "1"));
            json.Add(new JProperty("type", type));
            string resultText = DoPostRequest("andropit_test/drops", json);
            return resultText;
        }
  
        private string DetermineType(string text)
        {
            if (text.Contains('@'))
            {
                return "email";
            }
            
            if (text.IndexOf("http") == 0)
            {
                return "url";
            }
            string potentialPhone = Regex.Replace(text, "[^.0-9]", string.Empty);
            if (potentialPhone.Length != 0)
            {
                return "phone";
            }
            return "text";


        }

        private string DoPostRequest(string action, JObject data)
        {
            Uri url = new Uri(serverUrl + action);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.ContentType = "application/json";
            req.Method = "POST";
            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(data.ToString());
            }
            HttpWebResponse httpResponse;
            try
            {
                httpResponse = (HttpWebResponse)req.GetResponse();
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Problem with {0}, {1}", url, exc.Message));
            }
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }
    }
}
