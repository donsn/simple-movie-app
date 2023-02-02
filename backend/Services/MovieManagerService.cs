using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Database;
using MovieMaster.Data.Models;

namespace MovieMaster.Services
{
	public class MovieManagerService : IMovieManagerService
	{
        private readonly ApplicationDbContext context;
        private readonly ILogger<MovieManagerService> logger;

        public MovieManagerService(ApplicationDbContext context, ILogger<MovieManagerService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Movie>> AddNewMovieAsync(Movie movie)
        {
            try
            {
                if (await context.Movies.AnyAsync(x=> x.Name.ToLower() == movie.Name.ToLower()))
                {
                    return new ApiResponse<Movie>(data: null!)
                    {
                        Message = "Movie already exists"
                    };
                }

                var result = await context.AddAsync(movie);
                await context.SaveChangesAsync();

                return new ApiResponse<Movie>(data: result.Entity)
                {
                    Message = "Created Successfully"
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to add a new movie");
            }

            return new ApiResponse<Movie>(default!)
            {
                Message = "Couldn't create a this movie"
            };
        }

        /// <summary>
        /// Add Movie Comment
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<ApiResponse<bool>> AddMovieCommentAsync(Guid Id, Comment comment)
        {
            try
            {
                if (await context.Comments.AnyAsync(x=> x.Movie.Id == Id
                && x.CreatedAt > DateTime.UtcNow.AddMinutes(5)
                && x.Content.ToLower() == comment.Content.ToLower()))
                {
                    return new ApiResponse<bool>(false)
                    {
                        Message = "Unable to add duplicate comment"
                    };
                }

                var movie = await context.Movies.FindAsync(Id);
                if (movie is null)
                {
                    return new ApiResponse<bool>(false)
                    {
                        Message = "Movie not found"
                    };
                }

                comment.Movie = movie;
                var result = await context.Comments.AddAsync(comment);
                await context.SaveChangesAsync();

                return new ApiResponse<bool>(true)
                {
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "unable to add comment");
            }

            return new ApiResponse<bool>(false)
            {
                Message = "Unable to add comment"
            };
        }

        /// <summary>
        /// Gets a movie by slug
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovieBySlugAsync(string slug)
		{
            try
            {
                if (string.IsNullOrEmpty(slug))
                {
                    return null!;
                }

                slug = slug.Replace("-", " ");

                var movie = await context.Movies.Where(x => x.Name.ToLower() == slug.ToLower())
                    .Include(x=> x.Genres)
                    .FirstOrDefaultAsync();

                return movie!;
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to get movie by slug");
            }

            return default!;
		}

        /// <summary>
        /// Gets all the movies
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Movie>> GetAllMoviesAsync()
        {
            try
            {
                return await context.Movies.Include(x => x.Genres).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to get all the movies");
            }

            return default!;
        }


        /// <summary>
        /// Gets all the movie genres
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Genre>> GetAllMovieGenresAsync()
        {
            try
            {
                return await context.Genres.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to get all the genres");
            }
            return default!;
        }

        /// <summary>
        /// Gets a movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie?> GetMovieByIdAsync(Guid id)
        {
            try
            {
                return await context.Movies.FindAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to get all the genres");
            }
            return default!;
        }
    }
}

