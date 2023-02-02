using System;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;

namespace MovieMaster.Services
{
	public interface IMovieManagerService
	{
        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<ApiResponse<Movie>> AddNewMovieAsync(Movie movie);

        /// <summary>
        /// Add Movie Comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddMovieCommentAsync(Guid Id, Comment comment);

        /// <summary>
        /// Gets a movie by slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        Task<Movie> GetMovieBySlugAsync(string slug);

        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Movie>> GetAllMoviesAsync();

        /// <summary>
        /// Gets all the movie genres
        /// </summary>
        /// <returns></returns>
       Task<IReadOnlyList<Genre>> GetAllMovieGenresAsync();

        /// <summary>
        /// Gets a movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Movie?> GetMovieByIdAsync(Guid id);
    }
}

