using System;
using MovieMaster.Data.Models.Base;

namespace MovieMaster.Data.Models
{
	/// <summary>
	/// A simple user
	/// </summary>
	public class User : Entity<int>
	{
		public string Name { get; set; } = default!;

		public string Username { get; set; } = default!;
	}
}

