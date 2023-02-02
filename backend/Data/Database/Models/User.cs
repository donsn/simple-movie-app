using System;
namespace MovieMaster.Data.Database.Models
{
	public class DbUser : Data.Models.User
	{
		public required string PasswordHash { get; set; }
	}
}

