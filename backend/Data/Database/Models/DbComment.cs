using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
    /// <inheritdoc />
    public class DbComment : Comment
	{
		public DbMovie Movie { get; set; } = default!;

		/// <summary>
		/// Returns a DB comment object
		/// </summary>
		public static DbComment FromComment(Comment comment)
		{
			return new DbComment
			{
				Id = comment.Id,
				Name = comment.Name,
				Content = comment.Content,
				CreatedAt = comment.CreatedAt,
			};
		}
	}
}

