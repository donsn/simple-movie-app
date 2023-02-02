using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Data.API.Models;
using MovieMaster.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMaster.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Gets the current user's profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<User> Get()
        {
            return Ok();
        }

        /// <summary>
        /// Logs in the user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public ActionResult<TokenModel> Login([FromBody]LoginModel model)
        {
            return Ok();
        }
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ApiResponse<User>> Post([FromBody] User user)
        {
            return Ok();
        }
    }
}

