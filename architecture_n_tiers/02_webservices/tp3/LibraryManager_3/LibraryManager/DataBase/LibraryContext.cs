using LibraryManager.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LibraryManager.Database
{
    public class LibraryContext : IdentityDbContext
    {
        public System.Data.Entity.DbSet<Book> Books { get; set; }

        public System.Data.Entity.DbSet<Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Subscriber> Subscribers { get; set; }

        public System.Data.Entity.DbSet<Librarian> Librarians { get; set; }
    }
}
