using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;
using MovieMaster.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMaster.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManagementService userManager;

        public UserController(IUserManagementService userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets the current user's profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<User>> GetAsync()
        {
            return Ok(await userManager.GetUserByUsernameAsync(User.Identity!.Name!));
        }

        /// <summary>
        /// Logs in the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<TokenModel>> LoginAsync([FromBody]LoginModel model)
        {
            return Ok( await userManager.LoginUserAsync(model.Username, model.Password ));
        }
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<User>>> PostAsync([FromBody] User user)
        {
            return Ok(await userManager.AddUserAsync(user));
        }
    }
}

