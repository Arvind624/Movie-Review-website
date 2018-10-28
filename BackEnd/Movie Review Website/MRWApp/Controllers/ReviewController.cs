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
    [RoutePrefix("api/movies/{movie_id}/reviews")]
    public class ReviewController : ApiController
    {
        private IReviewRepository repo;

        public ReviewController(IReviewRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet] [Route("")]
        public IHttpActionResult Get([FromUri] int movie_id)
        {
            return Ok(this.repo.GetAllReview(movie_id));
        }

        [HttpGet] [Route("{review_id}", Name="GetReview")]
        public IHttpActionResult Get([FromUri] int movie_id, int review_id) //Find Specific Review By Id
        {
            Review review = this.repo.GetSpecificReview(movie_id, review_id);

            return review == null ? StatusCode(HttpStatusCode.NoContent) : (IHttpActionResult)Ok(review);
        }

        [HttpPost] [Route("")]
        public IHttpActionResult Post([FromBody] Review review, [FromUri] int movie_id)
        {
            review.MovieId = movie_id;
            this.repo.Insert(review);
            string url = Url.Link("GetReview", new { review_id = review.Id });
            return Created(url, review);
        }

        [HttpPut] [Route("{review_id}")]
        public IHttpActionResult Put([FromBody] Review review, [FromUri] int movie_id, int review_id)
        {
            review.MovieId = movie_id;
            review.Id = review_id;
            this.repo.UpdateSpecificReview(review, movie_id, review_id);
            return Ok(review);
        }

        [HttpDelete] [Route("{review_id}")]
        public IHttpActionResult Delete([FromUri] int movie_id, int review_id)
        {
            int res = this.repo.DeleteSpecificReview(this.repo.GetSpecificReview(movie_id, review_id));
            return res == 1 ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.NotFound);
        }
    }
}
