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
using LibraryManager.Models;
using LibraryManager.Database;

namespace LibraryManager.Controllers
{
    public class SubscribersController : ApiController
    {
        private SubscriberContext db = new SubscriberContext();

        // GET: api/Subscribers
        public IQueryable<Subscriber> GetSubscribers()
        {
            return db.Subscribers;
        }

        // GET: api/Subscribers/5
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> GetSubscriber(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        // PUT: api/Subscribers/5
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

        // POST: api/Subscribers
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

        // DELETE: api/Subscribers/5
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