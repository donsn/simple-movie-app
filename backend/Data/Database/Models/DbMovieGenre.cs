using System;
namespace MovieMaster.Data.Database.Models
{
	public class DbMovieGenre
	{
		public int GenreId { get; set; }
		public Guid MovieId { get; set; }
	}
}

