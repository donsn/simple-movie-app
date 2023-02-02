using System;
namespace MovieMaster.Data.Database.Models
{
	public class MovieGenre
	{
		/// <summary>
		/// Movie
		/// </summary>
		public Guid MovieId { get; set; }
		/// <summary>
		/// Genre
		/// </summary>
		public int GenreId { get; set; }
	}
}

