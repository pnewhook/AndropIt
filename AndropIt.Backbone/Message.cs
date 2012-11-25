using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AndropIt.Backbone
{
    public class Message
    {
        public Message()
        {
            device_id = 1;
        }
        public int Id { get; set; }
        public int device_id { get; set; }
        private string _content;
        public string content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                if (value.Contains("@"))
                {
                    type = "email";
                }
                else if (value.IndexOf("http") == 0)
                {
                    type = "url";
                } else if (Regex.Replace(value, "[^.0-9]", string.Empty).Length != 0)
                {
                    type =  "phone";
                } else
                {
                    type = "text";
                }
            }
            }

        public string type { get; set; }
        public int owner_id { get; set; }
    }
}