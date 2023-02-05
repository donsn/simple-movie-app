using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters =
                          new TokenValidationParameters
                          {
                              ValidIssuers = new List<string> { "simple-app" },
                              ValidateIssuer = true,
                              ValidateIssuerSigningKey = true,
                              ValidateAudience = true,
                              ValidAudience = "simple-app-frontend",
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECURE_JWT_TOKEN"))
                          };
                        options.SaveToken = true;
                    });
            services.AddAuthorization();


            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IMovieManagerService, MovieManagerService>();
			services.AddCors();
            return services;
		}

		/// <summary>
		/// Adds the necessary services to the build
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
        public static IApplicationBuilder UseMovieApp(this IApplicationBuilder builder)
        {
			builder.UseCors(options =>
			{
				options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});
            builder.UseAuthentication();
            builder.UseAuthorization();
            builder.UseHttpsRedirection();
			builder.UseStaticFiles();

            InitializeDB.RunAsync(builder.ApplicationServices).Wait();

            return builder;
        }
    }
}

