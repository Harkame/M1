using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryManager.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext")
        {
            //Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());
        }

        public System.Data.Entity.DbSet<LibraryManager.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Subscriber> Subscribers { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Librarian> Librarians { get; set; }
    }
}
