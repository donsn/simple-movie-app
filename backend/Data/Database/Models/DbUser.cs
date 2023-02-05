using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
    /// <inheritdoc />
    public class DbUser : User
	{
		/// <summary>
		/// Converts this DB entity to a user object
		/// </summary>
		/// <returns></returns>
		public User ToUser()
		{
			return new User
			{
				Name = this.Name,
				Username = this.Username,
				// Never return the password
				PasswordHash = "",
				CreatedAt = this.CreatedAt
			};
		}
	}
}

