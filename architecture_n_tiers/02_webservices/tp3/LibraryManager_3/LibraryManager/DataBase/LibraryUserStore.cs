using Microsoft.AspNet.Identity.EntityFramework;

namespace LibraryManager.Database
{
    public class LibraryUserStore : UserStore<IdentityUser>
    {
        public LibraryUserStore() : base(new LibraryContext())
        {
        }
    }
}