using System.Data.Entity;

namespace LibraryManager.Database
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=BookContext")
        {
        }

        public System.Data.Entity.DbSet<LibraryManager.Models.Book> Books { get; set; }
    }
}
