using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;
using MovieMaster.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMaster.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieManagerService movieManager;

        public MoviesController(IMovieManagerService movieManager)
        {
            this.movieManager = movieManager;
        }

        /// <summary>
        /// Gets all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAsync()
        {
            return await movieManager.GetAllMoviesAsync();
        }

        /// <summary>
        /// Gets all movie genres
        /// </summary>
        /// <returns></returns>
        [HttpGet("Genres")]
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await movieManager.GetAllMovieGenresAsync();
        }

        /// <summary>
        /// Gets a movie by slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet("Slug/{slug}")]
        public async Task<Movie> GetAsync(string slug)
        {
            return await movieManager.GetMovieBySlugAsync(slug);
        }

        /// <summary>
        /// Creates a new movie
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Movie>>> PostAsync([FromBody] MovieObject model)
        {
            return Ok(await movieManager.AddNewMovieAsync(model));
        }

        // You must be signed in to post a comment
        /// <summary>
        /// Adds a comment to a movie
        /// </summary>
        /// <param name="model"></param>
        [Authorize] 
        [HttpPost("{id}/Comment")]
        public async Task<ActionResult<ApiResponse<bool>>> PostAsync(Guid id, [FromBody] Comment model)
        {
            return Ok(await movieManager.AddMovieCommentAsync(id, model));
        }
    }
}

