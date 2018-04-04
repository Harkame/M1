using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Models;
using LibraryManager.Database;
using System.Collections.Generic;

namespace LibraryManager.Controllers
{
    public class BooksController : ApiController
    {
        private BookContext db = new BookContext();

        public BooksController()
        {
            Book t_book = new Book { Title = "Title1", Author = "Author1", Stock = 12, Editor = "Editor1"};

            db.Books.Add(t_book);

            db.SaveChanges();
        }

        // GET: api/Books
        public IQueryable<Book> GetBooks()
        {
            DbSet<Book> r_books = db.Books;

            foreach(Book t_book in r_books)
            {
                using (CommentContext t_comment_context = new CommentContext())
                {
                    var query = t_comment_context.Comments.Where(c => c.BookID == t_book.ID);

                    t_book.Comments = query.ToList();
                }
            }

            return r_books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // GET: api/Books/5
        [ResponseType(typeof(List<Book>))]
        public async Task<IHttpActionResult> GetByAuthor(string p_author)
        {
            var query = db.Books.Where(c => c.Author.Equals(p_author));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            return Ok(query.ToList());
        }

        // PUT: api/Books/5
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

        // POST: api/Books
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

        // DELETE: api/Books/5
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