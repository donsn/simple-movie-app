using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.Database;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class DI
	{
		/// <summary>
		/// Adds the necessary services for the app to work
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddMovieApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(configuration["DATABASE_URL"]);
			});
			return services;
		}
	}
}

