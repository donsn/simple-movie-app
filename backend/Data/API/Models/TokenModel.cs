using System;
namespace MovieMaster.Data.API.Models
{
    /// <summary>
    /// Token
    /// </summary>
	public class TokenModel
    {
        /// <summary>
        /// Succeeded Status
        /// </summary>
        public bool Succeeded { get; set; } = false;
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; } = default!;
        /// <summary>
        /// Expiry Time
        /// </summary>
        public ulong Expiry { get; set; }
        /// <summary>
        /// Message to the front end
        /// </summary>
        public string Message { get; set; } = default!;
    }
}

