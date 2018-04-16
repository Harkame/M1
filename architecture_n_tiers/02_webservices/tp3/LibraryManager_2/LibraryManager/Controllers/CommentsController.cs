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

        [Route("api/comments/GetComments"), HttpGet]
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        [Route("api/comments/PostComment/{subscriber_id}"), HttpPost]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> PostComment(int subscriber_id, Comment comment)
        {
            if (!Library.SubscriberIsConnected(subscriber_id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Comment t_comment = db.Comments.Where(c => c.BookID == comment.BookID && c.SubscriberID == comment.SubscriberID).ToArray()[0];

            if (t_comment == null)
                db.Comments.Add(comment);
            else
                t_comment.Description = comment.Description;

            await db.SaveChangesAsync();

            return Ok("Comment added");
        }
    }
}