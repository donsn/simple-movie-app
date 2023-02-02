using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.Database;

namespace MovieMaster.Data
{
    public static class InitializeDB
    {

        public static async Task RunAsync(IServiceProvider serviceProvider)
        {
            var sp = serviceProvider.CreateScope().ServiceProvider;
            ApplicationDbContext applicationDbContext = sp.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext ?? default!;

            if (applicationDbContext is not null)
            {
                await applicationDbContext.Database.MigrateAsync();
            }
        }
    }
}

