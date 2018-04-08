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

        [Route("api/comments/GetComment/{id}"), HttpGet]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> GetCommentByID(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [Route("api/comments/GetCommentsByBookID/{id}"), HttpGet]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> GetCommentsByBookID(int id)
        {
            var query = db.Comments.Where(c => c.BookID.Equals(id));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            return Ok(query.ToList());
        }

        [Route("api/comments/GetCommentsBySubscriberID/{id}"), HttpGet]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> GetCommentsBySubscriberID(int id)
        {
            var query = db.Comments.Where(c => c.SubscriberID.Equals(id));

            if (await query.ToListAsync() == null)
            {
                return NotFound();
            }

            return Ok(query.ToList());
        }

        [Route("api/comments/PutComment/{id}/{comment}"), HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.ID)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/comments/PostComment/{comment}"), HttpPost]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comments.Add(comment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comment.ID }, comment);
        }

        [Route("api/comments/DeleteComment/{id}"), HttpDelete]
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            await db.SaveChangesAsync();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.ID == id) > 0;
        }
    }
}