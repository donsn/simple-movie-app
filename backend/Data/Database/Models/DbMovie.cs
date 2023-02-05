using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
	public class DbMovie : Movie
	{
		public List<DbComment> Comments { get; set; } = new List<DbComment>();
	}
}

