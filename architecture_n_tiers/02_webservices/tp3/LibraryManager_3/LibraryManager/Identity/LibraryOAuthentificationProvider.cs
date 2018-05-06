using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using LibraryManager.Database;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using LibraryManager.Models;

namespace LibraryManager.Identity
{
    public class LibraryOAuthentificationProvider : OAuthAuthorizationServerProvider
    {

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var authRepository = new AuthRepository())
            {
                await authRepository.RegisterSubscriber(new Subscriber(42, "Librarian1", "password123"));
                await authRepository.RegisterSubscriber(new Subscriber(42, "Subscriber1", "password321"));

                IdentityUser user = await authRepository.FindUser(context.UserName, context.Password);

                authRepository.SetupRoles();

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                var identity = SetClaimsIdentity(context, user);
                context.Validated(identity);

            }

        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context, IdentityUser user)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));

            var userRoles = context.OwinContext.Get<LibraryUserManager>().GetRoles(user.Id);
            foreach (var role in userRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }


            return identity;

        }
    }
}