using System;
using MovieMaster.Data.Models.Base;

namespace MovieMaster.Data.Models
{
	/// <summary>
	/// A simple movie genre
	/// </summary>
	public class Genre : Entity<int>
	{
		/// <summary>
		/// Name Of Genre
		/// </summary>
		public string Name { get; set; } = default!;
		/// <summary>
		/// Movies in this genre
		/// </summary>
		public List<Movie> Movies { get; set; } = default!;
	}
}

