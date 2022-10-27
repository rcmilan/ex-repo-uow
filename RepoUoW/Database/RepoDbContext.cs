﻿using Microsoft.EntityFrameworkCore;
using RepoUoW.Entities;

namespace RepoUoW.Database
{
    internal sealed class RepoDbContext : DbContext
    {
        public RepoDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            List<Country> countries = new()
            {
                new Country { Id = 1, Name = "o intankavel"}
            };

            modelBuilder.Entity<Country>().HasData(countries);
        }
    }
}