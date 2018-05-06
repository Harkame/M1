using Microsoft.Owin;
using Owin;
using LibraryManager.Database;
using System.Web.Http;

[assembly: OwinStartup(typeof(LibraryManager.Startup))]
namespace LibraryManager
{
    public partial class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        { 
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(appBuilder);

            WebApiConfig.Register(config);

            System.Data.Entity.Database.SetInitializer(new Initializer());
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);
        }
    }
}