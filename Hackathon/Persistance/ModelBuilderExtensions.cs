using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 1, Name = "First Departament" }

            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 2, Name = "Second Departament" }

            );
            modelBuilder.Entity<Departments>().HasData(
                new Departments { Id = 3, Name = "Third Departament" }

            );
        }
    }
}
