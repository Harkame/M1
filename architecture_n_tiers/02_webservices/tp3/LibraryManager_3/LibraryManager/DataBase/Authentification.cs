using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using LibraryManager.Models;

namespace LibraryManager.Database
{
    public class AuthRepository : IDisposable
    {
        private LibraryContext libraryContext;

        private LibraryUserManager libraryUserManager;


        public AuthRepository()
        {
            libraryContext = new LibraryContext();
            libraryUserManager = new LibraryUserManager();

        }

        public async void SetupRoles()
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

        public async Task<IdentityUser> FindUser(string nomInscrit, string mdpInscrit)
        {
            IdentityUser inscrit = await libraryUserManager.FindAsync(nomInscrit, mdpInscrit);

            return inscrit;
        }

        // Inscrit méthodes
        public async Task<IdentityResult> RegisterSubscriber(Subscriber subscriber)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = subscriber.UserName
            };


            var result = await libraryUserManager.CreateAsync(user, subscriber.Password);

            var role = libraryContext.Roles.SingleOrDefault(r => r.Name == "Subscriber");
            user.Roles.Add(new IdentityUserRole { RoleId = role.Id });

            await libraryUserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                libraryContext.Subscribers.Add(subscriber);
            }

            await libraryContext.SaveChangesAsync();
            return result;
        }

        public async Task<IdentityResult> UnRegisterInscrit(Subscriber subscriber)
        {
            IdentityUser user = await FindUser(subscriber.UserName, subscriber.Password);

            var result = await libraryUserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                libraryContext.Subscribers.Attach(subscriber);
                libraryContext.Subscribers.Remove(subscriber);
            }

            await libraryContext.SaveChangesAsync();
            return result;
        }

        //Bibliothecaire méthodes
        public async Task<IdentityResult> RegisterBibliothecaire(Librarian librarian)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = librarian.UserName
            };

            var result = await libraryUserManager.CreateAsync(user, librarian.Password);

            var role = libraryContext.Roles.SingleOrDefault(r => r.Name == "Librarian");
            user.Roles.Add(new IdentityUserRole { RoleId = role.Id });

            await libraryUserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                libraryContext.Librarians.Add(librarian);
            }

            await libraryContext.SaveChangesAsync();
            return result;
        }

        public async Task<IdentityResult> UnRegisterBibliothecaire(Librarian librarian)
        {
            IdentityUser user = await FindUser(librarian.UserName, librarian.Password);

            var result = await libraryUserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                libraryContext.Librarians.Attach(librarian);
                libraryContext.Librarians.Remove(librarian);
            }

            await libraryContext.SaveChangesAsync();
            return result;
        }


        public void Dispose()
        {
            libraryContext.Dispose();
            libraryUserManager.Dispose();

        }
    }
}