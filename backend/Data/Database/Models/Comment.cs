using System;
namespace MovieMaster.Data.Database.Models
{
	public class DbComment : Data.Models.Comment
	{
		public Guid MovieId { get; set; }

	}
}

