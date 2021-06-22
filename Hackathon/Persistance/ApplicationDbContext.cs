using Microsoft.EntityFrameworkCore;
using Hackathon.Models;
using Hackathon.Persistance;

namespace Hackathon.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<Issues> Issues { get; set; }
        public DbSet<Pins> Pins { get; set; }
        public DbSet<PinTypes> PinTypes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Works> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DepartamentsSeed();
            modelBuilder.StatusSeed();
            modelBuilder.PinTypeSeed();
        }
    }
}
