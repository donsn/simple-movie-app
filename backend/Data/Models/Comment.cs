using System;
using MovieMaster.Data.Models.Base;

namespace MovieMaster.Data.Models
{
	/// <summary>
	/// A simple comment
	/// </summary>
	public class Comment : Entity<Guid>
	{
		public required string Name { get; set; }

		public required string Content { get; set; }

		public virtual Movie Movie { get; set; } = default!;
	}
}

