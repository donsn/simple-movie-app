using System;
namespace MovieMaster.Data.API.Models
{
    /// <summary>
    /// Base API Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> : object
    {
        public ApiResponse(T data)
        {
            // check if it is null or a boolean
            if (data != null && data?.GetType() != typeof(bool))
            {
                Status = true;
            }
            else
            {
                // return the boolean value
                Status = bool.Parse(data?.ToString() ?? false.ToString());
            }

            this.data = data;
        }
        /// <summary>
        /// Request Status
        /// </summary>
        public bool Status { get; }
        /// <summary>
        /// Data
        /// </summary>
        public T? data { get; } = default!;
        /// <summary>
        /// Error or Success Messages
        /// </summary>
        public string? Message { get; set; } = default;
    }
}

