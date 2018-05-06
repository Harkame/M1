using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LibraryManager.Connections;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class CommentsController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        [Authorize(Roles = "Librarian, Subscriber")]
        [Route("api/comments/GetComments"), HttpGet]
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        [Authorize(Roles = "Subscriber")]
        [Route("api/comments/PostComment/{subscriber_id}"), HttpPost]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> PostComment(int subscriber_id, Comment comment)
        {
            if (!Library.SubscriberIsConnected(subscriber_id))
                return NotFound();

            //Problem with SQL integrity, we manage it here
            //If comment (BookID + SubscriberId) already exist, update the description, else add it
            var t_comment = db.Comments.Where(c => c.BookID == comment.BookID && c.SubscriberID == comment.SubscriberID).ToArray();

            if (t_comment.Length == 0)
                db.Comments.Add(comment);
            else
                t_comment[0].Description = comment.Description;

            await db.SaveChangesAsync();

            return Ok("Comment added");
        }
    }
}