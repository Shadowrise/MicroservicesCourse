using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlatformsService.Models;

namespace PlatformsService.Data
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            try
            {
                Console.WriteLine("--> Migrations started...");
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Migrations failed: {ex.Message}");
                throw;
            }

            return host;
        }
        
        public static IHost SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            try
            {
                if (!context.Platforms.Any())
                {
                    Console.WriteLine("--> Seeding started...");
                    context.Platforms.AddRange(
                        new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                        new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                        new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Seeding failed: {ex.Message}");
                throw;
            }

            return host;
        }
    }
}