using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AndropIt.Core
{
    public class PushClient : IPushClient
    {
        private readonly string pwAuth = "rlL8SEZCf+wFip4bZSSf64swv9+AE66hi+4BkWEq4BB83FnDH9mwJGROQMlz4LX/EHXfkYiNMhN8NKTeXoTu";
        private readonly string pwApplication = "59130-6BCC8";
        
        public PushClient()
        {

        }

        public string SendText(string text)
        {
            //TODO: implement
            return "success";
        }

        private void PWCall(string action, JObject data)
        {
            Uri url = new Uri("https://cp.pushwoosh.com/json/1.3/" + action);
            JObject json = new JObject(new JProperty("request", data));
            //DoPostRequest(url, json);
        }
    }
}
