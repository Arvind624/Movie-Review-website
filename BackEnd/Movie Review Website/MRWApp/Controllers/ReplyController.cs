using MRWEntity;
using MRWInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRWApp.Controllers
{
    [RoutePrefix("api/movies/{movie_id}/reviews/{review_id}/replies")]
    public class ReplyController : ApiController
    {
        private IReplyRepository repo;

        public ReplyController(IReplyRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet] [Route("")]
        public IHttpActionResult Get([FromUri] int movie_id, int review_id)
        {
            return Ok(this.repo.GetAllReplies(movie_id, review_id));
        }

        [HttpGet] [Route("{reply_id}", Name="GetReply")]
        public IHttpActionResult Get([FromUri] int movie_id, int review_id, int reply_id)
        {
            Reply reply = this.repo.GetSpecificReply(movie_id, review_id, reply_id);

            return reply == null ? StatusCode(HttpStatusCode.NoContent) : (IHttpActionResult)Ok(reply);
        }

        [HttpPost] [Route("")]
        public IHttpActionResult Post([FromBody] Reply reply, [FromUri] int movie_id, int review_id)
        {
            reply.MovieId = movie_id;
            reply.Review_Id = review_id;
            this.repo.Insert(reply);
            string url = Url.Link("GetReply", new { reply_id = reply.Id });
            return Created(url, reply);
        }

        [HttpPut] [Route("{reply_id}")]
        public IHttpActionResult Put([FromBody] Reply reply, [FromUri] int movie_id, int review_id, int reply_id)
        {
            reply.MovieId = movie_id;
            reply.Review_Id = review_id;
            reply.Id = reply_id;
            this.repo.UpdateSpecificReply(reply, movie_id, review_id, reply_id);
            return Ok(reply);
        }

        [HttpDelete] [Route("{reply_id}")]
        public IHttpActionResult Delete([FromUri] int movie_id, int review_id, int reply_id)
        {
            int res = this.repo.DeleteSpecificReply(this.repo.GetSpecificReply(movie_id, review_id, reply_id));
            return res == 1 ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.NotFound);
        }
    }
}
