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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private ICategoryRepository repo;

        public CategoryController(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet] [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        [HttpGet] [Route("{category_id}", Name = "GetCategory")]
        public IHttpActionResult Get(int category_id)
        {
            Category cat = this.repo.Get(category_id);

            return cat == null ? StatusCode(HttpStatusCode.NoContent) : (IHttpActionResult)Ok(cat);
        }

        [HttpPost] [Route("")]
        public IHttpActionResult Post(Category category)
        {
            this.repo.Insert(category);
            string url = Url.Link("GetCategory", new { category_id = category.Id });
            return Created(url, category);
        }

        [HttpPut] [Route("{category_id}")]
        public IHttpActionResult Put([FromBody] Category category, [FromUri] int category_id)
        {
            category.Id = category_id;
            this.repo.Update(category);
            return Ok(category);
        }

        [HttpDelete] [Route("{category_id}")]
        public IHttpActionResult Delete(int category_id)
        {
            this.repo.Delete(this.repo.Get(category_id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
