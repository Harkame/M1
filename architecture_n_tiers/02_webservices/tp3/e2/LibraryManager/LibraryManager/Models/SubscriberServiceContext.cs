using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryManager.Models
{
    public class SubscriberServiceContext : DbContext
    {
        public SubscriberServiceContext() : base("name=subscriber_base")
        {
           // this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<Subscriber> Subscribers { get; set; }
    }
}