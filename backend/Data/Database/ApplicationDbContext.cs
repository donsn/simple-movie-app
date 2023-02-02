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

        public DbSet<DbUser> Users { get; set; }

        public DbSet<DbComment> Comments { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbMovie>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).IsRequired();
                x.HasIndex(x => x.Name);
                x.HasMany<MovieGenre>().WithOne().HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade);
                x.Property(x => x.LastModified).ValueGeneratedOnAddOrUpdate();

            });

            modelBuilder.Entity<DbGenre>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name);
                x.HasMany<MovieGenre>().WithOne().HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Cascade);
                x.Property(x => x.LastModified).ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<DbComment>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name);
                x.HasOne<DbMovie>().WithMany().HasForeignKey(f => f.MovieId);

            });

            modelBuilder.Entity<DbUser>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Username);

            });

            modelBuilder.Entity<MovieGenre>(x =>
            {
                x.HasKey(p => new { p.GenreId, p.MovieId });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

