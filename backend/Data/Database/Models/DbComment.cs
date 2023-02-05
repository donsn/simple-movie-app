using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
	public class DbComment : Comment
	{
		public DbMovie Movie { get; set; } = default!;
	}
}

