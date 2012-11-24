using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndropItWeb.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int device_id { get; set; }
        public string message { get; set; }
        public int content { get; set; }
        public string type { get; set; }
        public int owner_id { get; set; }
    }
}