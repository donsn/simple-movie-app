using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Database;
using MovieMaster.Data.Database.Models;
using MovieMaster.Data.Models;
using MovieMaster.Tools;

namespace MovieMaster.Services
{
	public class UserManagementService : IUserManagementService
	{
        private readonly ApplicationDbContext context;
        private readonly ILogger<UserManagementService> logger;

        public UserManagementService(ApplicationDbContext context, ILogger<UserManagementService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiResponse<User>> AddUserAsync(User user)
        {
            try
            {
                if (user is null)
                {
                    return new ApiResponse<User>(default!)
                    {
                        Message = "User is null"
                    };
                }

                if (await context.Users.AnyAsync(x=> x.Username.ToLower() == user.Username.ToLower()))
                {
                    return new ApiResponse<User>(default!)
                    {
                        Message = "This username already exists"
                    };
                }
                if (string.IsNullOrEmpty(user.PasswordHash))
                {
                    return new ApiResponse<User>(default!)
                    {
                        Message = "Please include a password"
                    };
                }
                user.PasswordHash = PasswordHasher.HashPasword(user.PasswordHash);
                var result = await context.Users.AddAsync((DbUser)user);
                await context.SaveChangesAsync();

                return new ApiResponse<User>(result.Entity)
                {
                    Message = "Successful"
                };
                

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error trying to add user");
            }

            return new ApiResponse<User>(default!)
            {
                Message = "Unable to create a new user"
            };
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<TokenModel> LoginUserAsync(string username, string password)
        {
            try
            {
                var user = await context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
                if (user is not null)
                {
                    if (PasswordHasher.VerifyPassword(password, user.PasswordHash!))
                    {
                        return JwtHelper.GenerateToken(user);
                    }

                    return new TokenModel
                    {
                        Message = "Invalid login credentials"
                    };
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to login user");
            }

            return new TokenModel
            {
                Message = "Unable to log you in"
            };
        }

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unable to get user by username");
            }

            return default!;
        }
    }
}

