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
    public class BooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Route("api/books/GetBooks/{user_id}"), HttpGet]
        public IQueryable<Book> GetBooks(int user_id)
        {
            if (!Library.LibrarianIsConnected(user_id) && !Library.SubscriberIsConnected(user_id))
                return null;
            else
                return db.Books;
        }

        [Route("api/books/GetBookByID/{user_id}/{book_id}"), HttpGet]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBookByID(int user_id, int book_id)
        {
            if (!Library.LibrarianIsConnected(user_id) && !Library.SubscriberIsConnected(user_id))
                return NotFound();

            Book book = await db.Books.FindAsync(book_id);
            if (book == null)
                return NotFound();


            var query2 = db.Comments.Where(c => c.BookID == book.ID);

            book.Comments = query2.ToList();


            return Ok(book);
        }

        [Route("api/books/GetBooksByAuthor/{user_id}/{author}"), HttpGet]
        [ResponseType(typeof(List<Book>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(int user_id, string author)
        {
            if (!Library.LibrarianIsConnected(user_id) && !Library.SubscriberIsConnected(user_id))
                return NotFound();

            var query = db.Books.Where(c => c.Author.ToLower().Equals(author.ToLower()));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            return Ok(query.ToList());
        }

        [Route("api/books/PostBook/{librarian_id}"), HttpPost]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(int librarian_id, Book book)
        {
            if (!Library.LibrarianIsConnected(librarian_id))
                return NotFound();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = book.ID }, book);
            return Ok("Book added");
        }

    }
}