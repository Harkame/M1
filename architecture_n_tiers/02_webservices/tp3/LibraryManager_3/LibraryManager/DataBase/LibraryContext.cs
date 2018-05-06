using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LibraryManager.Database
{
    public class LibraryContext : IdentityDbContext
    {
        public System.Data.Entity.DbSet<LibraryManager.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Subscriber> Subscribers { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Librarian> Librarians { get; set; }
    }
}
