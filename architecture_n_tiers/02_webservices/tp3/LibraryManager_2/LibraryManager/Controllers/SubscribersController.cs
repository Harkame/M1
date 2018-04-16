using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Connections;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class SubscribersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Route("api/subscribers/GetSubscribersByID/{id}"), HttpGet]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> GetSubscribersByID(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        [Route("api/subscribers/GetCommands/{id}"), HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetCommands(int id)
        {
            if (!Library.LibrarianIsConnected(id))
                return NotFound();

            List<string> r_commands = new List<string>();

            r_commands.Add("Actions :");
            r_commands.Add("[1] : Show books");
            r_commands.Add("[2] : Search book by ID");
            r_commands.Add("[3] : Search book by Author");
            r_commands.Add("[4] : Comment book");
            r_commands.Add("[5] : Disconnect");

            return Ok(r_commands);
        }

        [Route("api/subscribers/Authentificate"), HttpPut]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> Authentificate(Subscriber p_subscriber)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(p_subscriber.ID);

            if (subscriber == null)
                return NotFound();

            if (!subscriber.Password.ToLower().Equals(subscriber.Password.ToLower()))
                return NotFound();

            if (Library.Subscribers.Contains(subscriber))
                return Ok("Already connected");

            Library.Subscribers.Add(subscriber);

            return Ok("Authentificated");
        }

        [Route("api/subscribers/Disconnect/{id}"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Disconnect(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);

            if (subscriber == null)
                return NotFound();

            if (!Library.Subscribers.Contains(subscriber))
                return NotFound();

            Library.Subscribers.Remove(subscriber);

            return Ok("Disconnected");
        }

        [Route("api/subscribers/PostSubscriber"), HttpPost]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Subscribers.Add(subscriber);
            await db.SaveChangesAsync();

            return Ok(subscriber); //To know the id
        }
    }
}