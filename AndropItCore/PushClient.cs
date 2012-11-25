using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AndropIt.Core
{
    public class PushClient : IPushClient
    {
        private readonly string serverUrl = "http://10.32.110.50:8080/"; //"http://localhost:65258/";
        
        public PushClient()
        {

        }
        public string SendFile(string path)
        {
            WebClient client = new WebClient();
            try
            {
                client.UploadFile(serverUrl + "andropit_test/rest/files", path);
                return "Winning!";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Something wen't wrong";
            }
        }

        public string SendText(string text)
        {
            Message message = new Message();
            message.content = text.Trim();
            Console.WriteLine(message.content + " is " + message.type);
            string json = JsonConvert.SerializeObject(message);
            string resultText = DoPostRequest("andropit_test/rest/drops", json);//"api/message"
            return resultText;
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
                Console.WriteLine(string.Format("Problem with {0}, {1}", url, exc.Message));
                return "All messed up";
            }
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }
    }
}
