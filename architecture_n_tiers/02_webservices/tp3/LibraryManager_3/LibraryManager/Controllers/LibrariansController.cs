using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Models;
using LibraryManager.Connections;
using System.Collections.Generic;
using LibraryManager.Database;

namespace LibraryManager.Controllers
{
    public class LibrariansController : ApiController
    {
        private LibraryContext db = new LibraryContext();

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

        [Route("api/librarians/GetCommands/"), HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetCommands()
        {
            List<string> r_commands = new List<string>();

            r_commands.Add("Actions :");
            r_commands.Add("[1] : Show books");
            r_commands.Add("[2] : Search book by ID");
            r_commands.Add("[3] : Search book by Author");
            r_commands.Add("[4] : Add book");
            r_commands.Add("[5] : Disconnect");

            return Ok(r_commands);
        }

        [Route("api/librarians/PostLibrarian"), HttpPost]
        [ResponseType(typeof(Librarian))]
        public async Task<IHttpActionResult> PostLibrarian(Librarian librarian)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Librarians.Add(librarian);
            await db.SaveChangesAsync();

            return Ok(librarian); //To know the id
        }
    }
}