using System.Data.Entity;

namespace LibraryManager.Database
{
    public class SubscriberContext : DbContext
    {
        public SubscriberContext() : base("name=SubscriberContext")
        {
        }

        public System.Data.Entity.DbSet<LibraryManager.Models.Subscriber> Subscribers { get; set; }
    }
}
