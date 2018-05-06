using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Connections;
using LibraryManager.Database;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class SubscribersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Authorize(Roles = "Librarian")]
        [Route("api/subscribers/GetSubscribersByID/{id}"), HttpGet]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> GetSubscribersByID(int id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

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

        [Authorize(Roles = "Librarian")]
        [Route("api/subscribers/PostSubscriber"), HttpPost]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Subscribers.Add(subscriber);
            await db.SaveChangesAsync();

            return Ok(subscriber); //To know the id
        }
    }
}