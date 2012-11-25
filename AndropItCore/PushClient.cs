using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AndropIt.Core
{
    public class PushClient : IPushClient
    {
        private readonly string serverUrl = "http://localhost:65258/";
        
        public PushClient()
        {

        }

        public string SendText(string text)
        {
            Message message = new Message();
            message.content = text.Trim();
            Console.WriteLine(message.content + " is " + message.type);
            string json = JsonConvert.SerializeObject(message);
            string resultText = DoPostRequest("api/message", json);
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

        private string DoPostRequest(string action, string data)
        {
            Uri url = new Uri(serverUrl + action);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.ContentType = "application/json";
            req.Method = "POST";
            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(data);
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
