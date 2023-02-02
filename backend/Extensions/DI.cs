using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data;
using MovieMaster.Data.Database;
using MovieMaster.Services;

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

			services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IMovieManagerService, MovieManagerService>();
            return services;
		}

		/// <summary>
		/// Adds the necessary services to the build
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
        public static IApplicationBuilder UseMovieApp(this IApplicationBuilder builder)
        {
            builder.UseAuthentication();
            builder.UseAuthorization();
            builder.UseHttpsRedirection();

            InitializeDB.RunAsync(builder.ApplicationServices).Wait();

            return builder;
        }
    }
}

