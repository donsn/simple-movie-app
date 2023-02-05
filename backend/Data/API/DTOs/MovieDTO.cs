using System;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.API.DTOs
{
    /// <inheritdoc />
    public class MovieDTO : Movie
	{
        /// <summary>
        /// Genre
        /// </summary>
        public List<Genre> Genres { get; set; } = new List<Genre>();

        /// <summary>
        /// Movie Comments
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}

