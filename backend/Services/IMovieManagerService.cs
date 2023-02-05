using System;
using MovieMaster.Data.API.DTOs;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;

namespace MovieMaster.Services
{
	public interface IMovieManagerService
	{
        /// <summary>
        /// Uploads a movie poster
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<ApiResponse<string>> AddMoviePosterAsync(IFormFile file);
        /// <summary>
        /// Adds a new movie by uploading the file to wwwroot/images
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<ApiResponse<MovieDTO>> AddNewMovieAsync(MovieObject movie);
        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<ApiResponse<MovieDTO>> AddNewMovieAsync(MovieDTO movie);

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
        Task<MovieDTO?> GetMovieBySlugAsync(string slug);

        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<MovieDTO>> GetAllMoviesAsync();

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

