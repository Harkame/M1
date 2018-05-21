using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Database;
using LibraryManager.Models;
using Microsoft.AspNet.Identity;

namespace LibraryManager.Controllers
{
    public class SubscribersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Authorize(Roles = "Subscriber")]
        [Route("api/subscribers/GetCommands"), HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetCommands()
        {
            List<string> r_commands = new List<string>();

            r_commands.Add("Actions :");
            r_commands.Add("[1] : Show books");
            r_commands.Add("[2] : Search book by ID");
            r_commands.Add("[3] : Search book by Author");
            r_commands.Add("[4] : Comment book");
            r_commands.Add("[5] : Disconnect");

            return Ok(r_commands);
        }

        [AllowAnonymous]
        [Route("api/subscribers/PostSubscriber"), HttpPost]
        public async Task<IHttpActionResult> Post(Subscriber subscriber)
        {
            using (var authRepository = new Authentification())
            {
                IdentityResult result = await authRepository.RegisterSubscriber(subscriber);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok(subscriber);
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}