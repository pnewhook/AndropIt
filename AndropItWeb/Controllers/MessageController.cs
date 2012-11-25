using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AndropItWeb.Models;

namespace AndropItWeb.Controllers
{
    public class MessageController : ApiController
    {
        // GET api/message
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/message
        public HttpResponseMessage Post([FromBody]
                                        Message message)
        {
            AndropItDb db = new AndropItDb();
            db.Messagess.Add(message);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, message);
        }

        // PUT api/message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/message/5
        public void Delete(int id)
        {
        }
    }
}
