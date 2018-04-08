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

        [Route("api/subscribers/GetSubscribers"), HttpGet]
        public IQueryable<Subscriber> GetSubscribers()
        {
            return db.Subscribers;
        }

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

        [Route("api/subscribers/PutSubscriber/{id}/{subscriber}"), HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscriber(int id, Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.ID)
            {
                return BadRequest();
            }

            db.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/subscribers/Authentificate"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Authentificate(int id, string password)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            if (!subscriber.Password.ToLower().Equals(password.ToLower()))
                return NotFound();

            Library.Subscribers.Add(subscriber);

            return Ok("Authentificate");
        }

        [Route("api/subscribers/Disconnect"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Disconnect(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            if (!Library.Subscribers.Contains(subscriber))
                return NotFound();

            Library.Subscribers.Remove(subscriber);

            return Ok("Disconnected");
        }

        [Route("api/subscribers/PostSubscriber/{subscriber}"), HttpPost]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscribers.Add(subscriber);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subscriber.ID }, subscriber);
        }

        [Route("api/subscribers/DeleteSubscriber/{id}"), HttpDelete]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> DeleteSubscriber(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            db.Subscribers.Remove(subscriber);
            await db.SaveChangesAsync();

            return Ok(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriberExists(int id)
        {
            return db.Subscribers.Count(e => e.ID == id) > 0;
        }
    }
}