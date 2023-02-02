using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMaster.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        /// <summary>
        /// Gets all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Enumerable.Empty<Movie>();
        }

        /// <summary>
        /// Gets a movie by slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet("{slug}")]
        public Movie Get(string slug)
        {
            return new Movie { };
        }

        /// <summary>
        /// Creates a new movie
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public ActionResult<ApiResponse<Movie>> Post([FromBody] Movie model)
        {
            return Ok();
        }

        /// <summary>
        /// Adds a comment to a movie
        /// </summary>
        /// <param name="model"></param>
        [HttpPost("{id}")]
        public void Post(Guid id, [FromBody] Comment model)
        {

        }
    }
}

