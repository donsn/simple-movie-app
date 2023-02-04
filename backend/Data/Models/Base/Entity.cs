using System;
namespace MovieMaster.Data.Models.Base
{
	/// <summary>
	/// Base entity
	/// </summary>
	public abstract class Entity<TKey>
	{
		/// <summary>
		/// Primary key for the entity
		/// </summary>
		public TKey Id { get; set; } = default!;
		/// <summary>
		/// Created At
		/// </summary>
		public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
	}
}

