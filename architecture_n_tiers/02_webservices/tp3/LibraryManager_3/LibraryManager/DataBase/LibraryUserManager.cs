using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LibraryManager.Database
{
    public class LibraryUserManager : UserManager<IdentityUser>
    {
        public LibraryUserManager() : base(new LibraryUserStore())
        {
        }
    }
}