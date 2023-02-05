﻿using System;
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
        private readonly IWebHostEnvironment environment;

        public MovieManagerService(ApplicationDbContext context, ILogger<MovieManagerService> logger, IWebHostEnvironment environment)
        {
            this.context = context;
            this.logger = logger;
            this.environment = environment;
        }

        /// <summary>
        /// Uploads a movie poster
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ApiResponse<string>> AddMoviePosterAsync(IFormFile file)
        {
            try
            {
                if (file is null)
                {
                    return new ApiResponse<string>(default!)
                    {
                        Message = "Photo cannot be absent"
                    };
                }

                if (file.Length > 0)
                {
                    var extension = Path.GetExtension(file.FileName).ToLower().Trim();
                    var filename = Path.GetRandomFileName().Replace(".", "") + extension;
                    var folder = Path.Combine(environment.WebRootPath, "images", filename);

                    var filestream = new FileStream(folder, FileMode.Create);
                    await file.CopyToAsync(filestream);

                    return new ApiResponse<string>(filename)
                    {
                        Message = "Success"
                    };
                }
                else
                {
                    return new ApiResponse<string>(default!)
                    {
                        Message = "Empty file"
                    };
                }



            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to upload poster");
            }

            return new ApiResponse<string>(default!)
            {
                Message = "Couldn't upload movie poster"
            };
        }

        /// <summary>
        /// Adds a new movie by uploading the file to wwwroot/images
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Movie>> AddNewMovieAsync(MovieObject movie)
        {
            try
            {
                if (movie.Photo is null)
                {
                    return new ApiResponse<Movie>(default!)
                    {
                        Message = "Photo cannot be absent"
                    };
                }

                if (movie.Photo.Length > 0)
                {
                    var extension = Path.GetExtension(movie.Photo.FileName).ToLower().Trim();
                    var filename = Path.GetRandomFileName().Replace(".", "") + extension;
                    var folder = Path.Combine(environment.WebRootPath, "images", filename);

                    var filestream = new FileStream(folder, FileMode.Create);
                    await movie.Photo.CopyToAsync(filestream);

                    var _movie = new Movie
                    {
                        Photo = filename,
                        Name = movie.Name,
                        Description = movie.Description,
                        Slug = movie.Slug,
                        Comments = movie.Comments,
                        ReleaseDate = movie.ReleaseDate,
                        TicketPrice = movie.TicketPrice,
                        Country= movie.Country,
                        Genres= movie.Genres,
                        Rating = movie.Rating
                    };

                    return await AddNewMovieAsync(_movie);
                }
                else
                {
                    return new ApiResponse<Movie>(default!)
                    {
                        Message = "Empty file"
                    };
                }



            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to add a new movie");
            }

            return new ApiResponse<Movie>(default!)
            {
                Message = "Couldn't create this movie"
            };
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
                // Due to postgres check
                movie.ReleaseDate = DateTime.SpecifyKind(movie.ReleaseDate, DateTimeKind.Utc);

                /// Duplicate key bug with ef core
                var genres = await context.Genres.ToListAsync();

                var _modelGenres = movie.Genres.ToList();
                movie.Genres.Clear();

                foreach (var genre in genres)
                {
                    if (_modelGenres.Exists(x=> x.Id == genre.Id && x.Name == genre.Name))
                    {
                        movie.Genres.Add(genre);
                    }
                }

                foreach (var item in _modelGenres)
                {
                    if (movie.Genres.Exists(x=> x.Id == item.Id && x.Name == item.Name))
                    {
                        movie.Genres.Add(item);
                    }
                }
                ///

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
                Message = "Couldn't create this movie"
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
                

                var movie = await context.Movies.Where(x => x.Slug.ToLower() == slug.ToLower())
                    .Include(x=> x.Genres).Include(x=> x.Comments)
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

