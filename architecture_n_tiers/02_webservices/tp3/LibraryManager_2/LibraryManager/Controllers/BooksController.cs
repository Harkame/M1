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

namespace LibraryManager.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Route("api/books/GetBooks"), HttpGet]
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        [Route("api/books/GetBookByID/{book_id}"), HttpGet]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBookByID(int book_id)
        {
            Book book = await db.Books.FindAsync(book_id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Route("api/books/GetBooksByAuthor/{author}"), HttpGet]
        [ResponseType(typeof(List<Book>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(string author)
        {
            var query = db.Books.Where(c => c.Author.ToLower().Equals(author.ToLower()));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            return Ok(query.ToList());
        }

        [Route("api/books/PutBook/{id}/{book}"), HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.ID)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        [Route("api/books/PostBook/{book}"), HttpPost]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.ID }, book);
        }

        [Route("api/books/DeleteBook/{id}"), HttpDelete]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.ID == id) > 0;
        }
    }
}