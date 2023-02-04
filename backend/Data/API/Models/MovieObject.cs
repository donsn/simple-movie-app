using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.API.Models
{
	public class MovieObject : Movie
	{
		/// <summary>
		/// Photo is a file
		/// </summary>
		public new IFormFile Photo { get; set; } = default!;
	}
}

