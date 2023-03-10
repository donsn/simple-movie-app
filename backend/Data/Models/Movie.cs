using System;
using System.Net.Sockets;
using MovieMaster.Data.Models.Base;

namespace MovieMaster.Data.Models
{
	/// <summary>
	/// A simple movie
	/// </summary>
	public class Movie : Entity<Guid>
	{
		/// <summary>
		/// Name of the movie
		/// </summary>
		public string Name { get; set; } = default!;
		/// <summary>
		/// Movie description
		/// </summary>
		public string Description { get; set; } = default!;
		/// <summary>
		/// Release Date
		/// </summary>
		public DateTime ReleaseDate { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
		/// <summary>
		/// Rating ( 1 - 5 )
		/// </summary>
		public int Rating { get; set; } = default!;
		/// <summary>
		/// Ticket Price
		/// </summary>
		public decimal TicketPrice { get; set; } = default!;
		/// <summary>
		/// Country
		/// </summary>
		public string Country { get; set; } = default!;

        /// <summary>
        /// Image of the movie
        /// </summary>
        public string Photo { get; set; } = default!;

		/// <summary>
		/// Movie slug
		/// </summary>
		public string Slug { get; set; } = default!;
	}

}

