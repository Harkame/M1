using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Models;
using LibraryManager.Database;

namespace LibraryManager.Controllers
{
    public class BooksController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Authorize(Roles = "Librarian, Subscriber")]
        [Route("api/books/GetBooks/"), HttpGet]
        public IQueryable<Book> GetBooks()
        {
            var books = db.Books;

            foreach(Book book in books)
            {
                var comment_query = db.Comments.Where(c => c.BookID == book.ID);

                book.Comments = comment_query.ToList();
            }

            return books;
        }

        [Authorize(Roles = "Librarian, Subscriber")]
        [Route("api/books/GetBookByID/{book_id}"), HttpGet]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBookByID(int book_id)
        {
            Book book = await db.Books.FindAsync(book_id);
            if (book == null)
                return NotFound();

            var comment_query = db.Comments.Where(c => c.BookID == book.ID);

            book.Comments = comment_query.ToList();

            return Ok(book);
        }

        [Authorize(Roles = "Librarian, Subscriber")]
        [Route("api/books/GetBooksByAuthor/{author}"), HttpGet]
        [ResponseType(typeof(List<Book>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(string author)
        {
            var query = db.Books.Where(c => c.Author.ToLower().Equals(author.ToLower()));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            foreach (Book book in query)
            {
                var comment_query = db.Comments.Where(c => c.BookID == book.ID);

                book.Comments = comment_query.ToList();
            }

            return Ok(query.ToList());
        }

        [Authorize(Roles="Librarian")]
        [Route("api/books/PostBook/"), HttpPost]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return Ok("Book added");
        }

        [Authorize(Roles = "Librarian")]
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
    }
}