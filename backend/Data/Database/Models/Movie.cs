using System;
namespace MovieMaster.Data.Database.Models
{
	public class DbMovie : Data.Models.Movie
	{
		public virtual new ICollection<DbGenre> Genres { get; set; } = default!;
	}
}

