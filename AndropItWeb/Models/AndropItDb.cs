using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AndropItWeb.Models
{
    public class AndropItDb : DbContext
    {
        public DbSet<Message> Messagess { get; set; }
    }
}