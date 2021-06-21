using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static void DepartamentsSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 1, Name = "First Departament",Email = "first.department@sibiu_inventory.com" }
            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 2, Name = "Second Departament", Email = "second.department@sibiu_inventory.com" }
            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 3, Name = "Third Departament", Email = "third.department@sibiu_inventory.com" }
            );
        }

        public static void StatusSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Pending" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 2, Name = "Ongoing" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 3, Name = "Finished" }
            );
        }

        public static void PinTypeSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 1, Name = "Housing" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 2, Name = "Collective Housing" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 3, Name = "Commercial" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 4, Name = "Turism" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 5, Name = "Industrial" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 6, Name = "Sport" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 7, Name = "Health" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 8, Name = "Education and Research" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 9, Name = "Culture" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 10, Name = "Religious" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 11, Name = "Infrastructure" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 12, Name = "Office Building" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 13, Name = "Historical" }
            );
            modelBuilder.Entity<PinTypes>().HasData(
                new PinTypes { Id = 14, Name = "Special" }
            );
        }
    }
}
