using System.Data.Entity;

namespace LibraryManager.Database
{
    public class LibrarianContext : DbContext
    {
        public LibrarianContext() : base("name=LibrarianContext")
        {
        }

        public System.Data.Entity.DbSet<LibraryManager.Models.Librarian> Librarians { get; set; }
    }
}
