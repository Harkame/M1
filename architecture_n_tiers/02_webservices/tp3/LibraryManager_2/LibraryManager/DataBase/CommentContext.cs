using System.Data.Entity;

namespace LibraryManager.Database
{
    public class CommentContext : DbContext
    {
        public CommentContext() : base("name=CommentContext")
        {
        }

        public System.Data.Entity.DbSet<LibraryManager.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryManager.Models.Subscriber> Subscribers { get; set; }
    }
}
