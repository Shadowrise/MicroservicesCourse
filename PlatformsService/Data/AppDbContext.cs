using System;
using Microsoft.EntityFrameworkCore;
using PlatformsService.Models;

namespace PlatformsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}