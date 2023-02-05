using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.Database.Models;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DbMovie> Movies { get; set; }

        public DbSet<DbGenre> Genres { get; set; }

        public DbSet<DbMovieGenre> MovieGenres { get; set; }

        public DbSet<DbUser> Users { get; set; }

        public DbSet<DbComment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbMovie>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).IsRequired();
                x.HasMany<DbMovieGenre>().WithOne().HasForeignKey(f => f.MovieId).OnDelete(DeleteBehavior.Cascade);
                x.HasMany(c=> c.Comments).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
                x.HasIndex(x => x.Name);
                x.HasIndex(x => x.Slug);
            });

            modelBuilder.Entity<DbGenre>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name).IsUnique();
                x.HasMany<DbMovieGenre>().WithOne().HasForeignKey(f => f.GenreId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DbMovieGenre>(x =>
            {
                x.HasKey(p => new {p.MovieId, p.GenreId});
            });


            modelBuilder.Entity<DbComment>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name);
            });

            modelBuilder.Entity<DbUser>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Username);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

