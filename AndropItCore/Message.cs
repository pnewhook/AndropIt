using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AndropIt.Core
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
                if (value.Contains('@'))
                {
                    type = "email";
                } else if (value.IndexOf("http") == 0)
                {
                    type = "url";
                }
                else if (Regex.IsMatch(value, @"^[0-9\(\)\- +]+$"))
                {
                    type =  "phone";
                }
                else if (Regex.IsMatch(value,@"\w\d, +\w"))
                {
                    type = "addr";
                }
                else
                {
                    type = "text";
                }
            }
            }

        public string type { get; set; }
        public int owner_id { get; set; }
    }
}