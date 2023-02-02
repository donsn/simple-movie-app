using System;
namespace MovieMaster.Data.API.Models
{
	public class LoginModel
	{
		public required string Username { get; set; }
		public required string Password { get; set; }
	}
}

