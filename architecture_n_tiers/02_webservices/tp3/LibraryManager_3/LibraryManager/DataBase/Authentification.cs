using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using LibraryManager.Models;

namespace LibraryManager.Database
{
    public class Authentification : IDisposable
    {
        private LibraryUserManager libraryUserManager;


        public Authentification()
        {
            libraryUserManager = new LibraryUserManager();
        }

        public async void SetupRoles()
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                var role = libraryContext.Roles.SingleOrDefault(r => r.Name == "Subscriber");
                if (role == null)
                {
                    libraryContext.Roles.Add(new IdentityRole { Name = "Subscriber" });

                }

                role = libraryContext.Roles.SingleOrDefault(r => r.Name == "Librarian");
                if (role == null)
                {
                    libraryContext.Roles.Add(new IdentityRole { Name = "Librarian" });
                }

                await libraryContext.SaveChangesAsync();
            }
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            IdentityUser inscrit = await libraryUserManager.FindAsync(username, password);

            return inscrit;
        }

        // Inscrit méthodes
        public async Task<IdentityResult> RegisterSubscriber(Subscriber subscriber)
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = subscriber.UserName,
                    
                };

                var result = await libraryUserManager.CreateAsync(user, subscriber.Password);

                var role = libraryContext.Roles.SingleOrDefault(r => r.Name == "Subscriber");
                user.Roles.Add(new IdentityUserRole { RoleId = role.Id });

                await libraryUserManager.UpdateAsync(user);

                await libraryContext.SaveChangesAsync();
                return result;
            }
        }

        public async Task<IdentityResult> UnRegisterSubscriber(Subscriber subscriber)
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                IdentityUser user = await FindUser(subscriber.UserName, subscriber.Password);

                var result = await libraryUserManager.DeleteAsync(user);

                await libraryContext.SaveChangesAsync();
                return result;
            }
        }

        //Bibliothecaire méthodes
        public async Task<IdentityResult> RegisterLibrarian(Librarian librarian)
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = librarian.UserName
                };

                var result = await libraryUserManager.CreateAsync(user, librarian.Password);

                var role = libraryContext.Roles.Single(r => r.Name == "Librarian");
                user.Roles.Add(new IdentityUserRole { RoleId = role.Id });

                await libraryUserManager.UpdateAsync(user);

                await libraryContext.SaveChangesAsync();
                return result;
            }
        }

        public async Task<IdentityResult> UnRegisterLibrarian(Librarian librarian)
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                IdentityUser user = await FindUser(librarian.UserName, librarian.Password);

                var result = await libraryUserManager.DeleteAsync(user);

                await libraryContext.SaveChangesAsync();
                return result;
            }
        }


        public void Dispose()
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                libraryContext.Dispose();
            }

            libraryUserManager.Dispose();

        }
    }
}