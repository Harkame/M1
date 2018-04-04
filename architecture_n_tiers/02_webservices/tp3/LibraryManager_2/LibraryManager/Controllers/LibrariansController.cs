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
    public class LibrariansController : ApiController
    {
        private LibrarianContext db = new LibrarianContext();

        // GET: api/Librarians
        public IQueryable<Librarian> GetLibrarians()
        {
            return db.Librarians;
        }

        // GET: api/Librarians/5
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> GetLibrarian(int id)
        {
            Librarian librarian = await db.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }

            return Ok(librarian);
        }

        // PUT: api/Librarians/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLibrarian(int id, Librarian librarian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != librarian.ID)
            {
                return BadRequest();
            }

            db.Entry(librarian).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarianExists(id))
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

        // POST: api/Librarians
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> PostLibrarian(Librarian librarian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Librarians.Add(librarian);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = librarian.ID }, librarian);
        }

        // DELETE: api/Librarians/5
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> DeleteLibrarian(int id)
        {
            Librarian librarian = await db.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }

            db.Librarians.Remove(librarian);
            await db.SaveChangesAsync();

            return Ok(librarian);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LibrarianExists(int id)
        {
            return db.Librarians.Count(e => e.ID == id) > 0;
        }
    }
}