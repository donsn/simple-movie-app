using System;
using MovieMaster.Data.API.DTOs;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database.Models
{
    /// <inheritdoc />
    public class DbMovie : Movie
	{
		/// <summary>
		/// Movie Comments
		/// </summary>
		public List<DbComment> Comments { get; set; } = new List<DbComment>();

		/// <summary>
		/// Returns a movie DTO
		/// </summary>
		/// <returns></returns>
		public MovieDTO ToMovieDTO()
		{
			return new MovieDTO
			{
				Id = this.Id,
				Name = this.Name,
				Description = this.Description,
				ReleaseDate = this.ReleaseDate,
				TicketPrice = this.TicketPrice,
				Country = this.Country,
				Photo = this.Photo,
				Rating = this.Rating,
				Slug = this.Slug,
				Comments = this.Comments.ConvertAll(x=> new Comment { Id= x.Id, Content = x.Content, Name = x.Name}),
				CreatedAt = this.CreatedAt,
			};
		}
	}
}

