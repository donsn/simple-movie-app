using System;
using MovieMaster.Data.Database;
using MovieMaster.Data.Models;

namespace MovieMaster.Services
{
	public class MovieManagerService : IMovieManagerService
	{
        private readonly ApplicationDbContext context;

        public MovieManagerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddNewMovieAsync(Movie movie)
        {

        }

        public void AddMovieCommentAsync(Guid Id, Comment comment)
        {

        }

        public void GetMovieBySlugAsync(string slug)
		{

		}

        public void GetMovieByIdAsync(Guid id)
        {

        }
    }
}

