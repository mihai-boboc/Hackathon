using Microsoft.EntityFrameworkCore;
using Hackathon.Models;

namespace Hackathon.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Buildings> Buildings { get; set; }
    }
}
