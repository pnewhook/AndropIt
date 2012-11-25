using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AndropIt.Backbone
{
    public class PushClient : IPushClient
    {
        private readonly string serverUrl = "http://10.32.110.50:8080/"; //"http://localhost:65258/";
        
        public PushClient()
        {

        }

        public string SendText(string text)
        {
            Message message = new Message();
            message.content = text.Trim();
            string json = JsonConvert.SerializeObject(message);
            string resultText = DoPostRequest("andropit_test/drops", json);//"api/message"
            return resultText;
        }
  
        private string DoPostRequest(string action, string data)
        {
            
            Uri url = new Uri(serverUrl + action);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.ContentType = "application/json";
            req.Method = "POST";
            
            //using (var streamWriter = new StreamWriter(req.BeginGetRequestStream()))
            //{
            //    streamWriter.Write(data);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}
            HttpWebResponse httpResponse;
            try
            {
                httpResponse = (HttpWebResponse)req.GetResponseAsync();
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
