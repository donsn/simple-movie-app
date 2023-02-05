using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
    /// <inheritdoc />
    public class DbGenre : Genre
	{
        public virtual List<DbMovieGenre> MovieGenres { get; set; } = new List<DbMovieGenre>();

        /// <summary>
        /// Returns a DB Genre object
        /// </summary>
        public static DbGenre FromGenre(Genre genre)
        {
            return new DbGenre
            {
                Id = genre.Id,
                Name = genre.Name,
            };
        }
	}
}

