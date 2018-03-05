using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class SubscriberController : ApiController
    {
        SubscriberServiceContext db = new SubscriberServiceContext();

        public IEnumerable<Subscriber> Get()
        {
            return Library.a_subscribers.ToArray();
        }

        public Subscriber Get(int p_id)
        {
            foreach (Subscriber t_subscriber in Library.a_subscribers)
                if (t_subscriber.ID == p_id)
                     return t_subscriber;

            return null;
        }

        [HttpPost, Route("api/subscriber")]
        public void Post([FromBody]Subscriber subscriber)
        {
            throw new Exception(subscriber.Password);
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int p_id)
        {

        }
    }
}