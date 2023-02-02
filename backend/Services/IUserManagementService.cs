using System;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;

namespace MovieMaster.Services
{
	public interface IUserManagementService
	{
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApiResponse<User>> AddUserAsync(User user);

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<TokenModel> LoginUserAsync(string username, string password);

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
       Task<User?> GetUserByUsernameAsync(string username);

    }
}

