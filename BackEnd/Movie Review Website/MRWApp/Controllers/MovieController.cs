using MRWApp.Attributes;
using MRWEntity;
using MRWInterface;
using MRWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MRWApp.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private IMovieRepository repo;
        private IReviewRepository rRepo;

        public MovieController(IMovieRepository repo, IReviewRepository rRepo)
        {
            this.repo = repo;
            this.rRepo = rRepo;
        }

        [HttpGet] [Route("")] [BasicAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [HttpGet] [Route("{movie_id}", Name="GetMovie")]
        public IHttpActionResult Get(int movie_id)
        {
            Movie movie = this.repo.Get(movie_id);

            return movie == null ? StatusCode(HttpStatusCode.NoContent) : (IHttpActionResult) Ok(movie);
        }

        [HttpPost] [Route("")]
        public IHttpActionResult Post(Movie movie)
        {
            this.repo.Insert(movie);
            string url = Url.Link("GetMovie", new { movie_id = movie.Id });
            return Created(url, movie);
        }

        [HttpPut] [Route("{movie_id}")]
        public IHttpActionResult Put([FromBody] Movie movie, [FromUri] int movie_id)
        {
            movie.Id = movie_id;
            this.repo.Update(movie);
            return Ok(movie);
        }

        [HttpDelete] [Route("{movie_id}")]
        public IHttpActionResult Delete(int movie_id)
        {
            //Deleting reviews of that movie

            List<Review> allReview = this.rRepo.GetAllReview(movie_id);

            if(allReview != null)
            {
                foreach(Review review in allReview)
                {
                    this.rRepo.DeleteSpecificReview(review); // all replies are deleted too
                }
            }

            //Deleting movie
            this.repo.Delete(this.repo.Get(movie_id));
            return StatusCode(HttpStatusCode.NoContent);
        }

        /*[HttpGet] [Route("{movie_name}")]
        public IHttpActionResult GetMovieByName(string movie_name)
        {
            List<Movie> movieList = this.repo.SearchByName(movie_name);
            return movieList == null ? StatusCode(HttpStatusCode.NotFound) : (IHttpActionResult)Ok(movieList);
        }*/
    }
}
