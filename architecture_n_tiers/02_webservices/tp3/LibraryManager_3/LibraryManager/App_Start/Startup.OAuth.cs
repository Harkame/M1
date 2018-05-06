using System;
using LibraryManager.Database;
using LibraryManager.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace LibraryManager
{
    public partial class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new LibraryContext());
            app.CreatePerOwinContext(() => new LibraryUserManager());

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new LibraryOAuthentificationProvider(),
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}