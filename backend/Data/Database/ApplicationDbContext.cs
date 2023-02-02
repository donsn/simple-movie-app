using System;
using Microsoft.EntityFrameworkCore;
using MovieMaster.Data.Models;

namespace MovieMaster.Data.Database
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public Task<bool> AnyAsync { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(x =>
            {
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).IsRequired();
                x.HasIndex(x => x.Name);
                x.HasMany(x=> x.Genres).WithMany(x=> x.Movies);
                x.HasMany(x => x.Comments).WithOne(x => x.Movie);
                x.Property(x => x.LastModified).ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Genre>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name);
                x.Property(x => x.LastModified).ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Comment>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Name);
            });

            modelBuilder.Entity<User>(x =>
            {
                x.HasKey(p => p.Id);
                x.HasIndex(x => x.Username);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

