using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Models;
using LibraryManager.Connections;
using System.Text;
using System.Collections.Generic;

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

        [Route("api/librarians/GetCommands/{id}"), HttpGet]
        [ResponseType(typeof(Librarian))]
        public IHttpActionResult GetCommands(int id)
        {
            if (!Library.LibrarianIsConnected(id))
                return NotFound();

            List<string> r_commands = new List<string>();

            r_commands.Add("Actions :");
            r_commands.Add("[1] : Show books");
            r_commands.Add("[2] : Search book by ID");
            r_commands.Add("[3] : Search book by Author");
            r_commands.Add("[4] : Add book");
            r_commands.Add("[5] : Disconnect");

            return Ok(r_commands);
        }

        [Route("api/librarians/Authentificate"), HttpPut]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> Authentificate(Librarian p_librarian)
        {
            Librarian librarian = await db.Librarians.FindAsync(p_librarian.ID);

            if (librarian == null)
                return NotFound();

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

        [Route("api/librarians/PostLibrarian"), HttpPost]
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