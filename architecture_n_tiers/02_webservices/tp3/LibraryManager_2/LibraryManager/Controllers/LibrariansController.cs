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
using LibraryManager.Connections;

namespace LibraryManager.Controllers
{
    public class LibrariansController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Route("api/librarians/GetLibrarians"), HttpGet]
        public IQueryable<Librarian> GetLibrarians()
        {
            return db.Librarians;
        }

        [Route("api/librarians/GetLibrarianByID/{id}"), HttpGet]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> GetLibrarianByID(int id)
        {
            Librarian librarian = await db.Librarians.FindAsync(id);
            if (librarian == null)
            {
                return NotFound();
            }

            return Ok(librarian);
        }


        [Route("api/librarians/PutLibrarian/{id}/{librarian}"), HttpPut]
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

        [Route("api/librarians/Authentificate"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Authentificate(Librarian p_librarian)
        {
            Librarian librarian = await db.Librarians.FindAsync(p_librarian.ID);

            if (librarian == null)
            {
                return NotFound();
            }

            if (!librarian.Password.ToLower().Equals(p_librarian.Password.ToLower()))
                return NotFound();

            if (Library.Librarians.Contains(librarian))
                return Ok("Already connected");

            Library.Librarians.Add(librarian);

            return Ok("Authentificate");
        }

        [Route("api/librarians/Disconnect/{id}"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Disconnect(int id)
        {
            Librarian librarian = await db.Librarians.FindAsync(id);

            if (librarian == null)
            {
                return NotFound();
            }

            if (!Library.Librarians.Contains(librarian))
                return NotFound();

            Library.Librarians.Remove(librarian);

            return Ok("Disconnected");
        }

        [Route("api/subscribers/Disconnect"), HttpPost]
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

        [Route("api/librarians/DeleteLibrarian/{id}"), HttpDelete]
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