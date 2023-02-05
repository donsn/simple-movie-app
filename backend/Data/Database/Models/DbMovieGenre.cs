using System;
namespace MovieMaster.Data.Database.Models
{
	/// <summary>
	/// Join Table For Movie Genres
	/// </summary>
	public class DbMovieGenre
	{
		public int GenreId { get; set; }
		public Guid MovieId { get; set; }
	}
}

