using System;
using MovieMaster.Data.API.Models;
using System.Security.Claims;
using System.Text;
using MovieMaster.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MovieMaster.Tools
{
    public static class JwtHelper
    {
        /// <summary>
        /// Generate A Replenit JWT Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static TokenModel GenerateToken(User user, IEnumerable<string> roles = default!)
        {

            if (user != null)
            {

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UNSECURE_JWT_TOKEN"));

                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };
                // Add Roles
                if (roles is not null)
                {
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                var expiry = DateTime.Now.AddMinutes(31);
                var token = new JwtSecurityToken(
                    issuer: "simple-app",
                    audience: "simple-app-frontend",
                    claims,
                    expires: expiry,
                    signingCredentials: signingCredentials);

                var _token = new JwtSecurityTokenHandler().WriteToken(token);

                return new TokenModel
                {
                    Message = "Success",
                    // We need the expiry in universal time
                    Expiry = ConvertToTimestamp(token.ValidTo),
                    Token = _token,
                    Succeeded = true
                };
            }
            else
            {
                return new TokenModel
                {
                    Succeeded = false,
                    Message = "Invalid login"
                };
            }
        }

        // https://stackoverflow.com/a/9814280/13781618
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// Converts date to timestamp
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static ulong ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - Epoch;
            return (ulong)elapsedTime.TotalSeconds;
        }
    }
}

