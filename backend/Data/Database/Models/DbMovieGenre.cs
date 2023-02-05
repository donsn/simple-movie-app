using System;
namespace MovieMaster.Data.Database.Models
{
	/// <summary>
	/// Join Table For Movie Genres
	/// </summary>
	public class DbMovieGenre
	{
		public int GenreId { get; set; }
		public virtual DbGenre Genre { get; set; } = default!;

		public Guid MovieId { get; set; }
		public virtual DbMovie Movie { get; set; } = default!;
	}
}

