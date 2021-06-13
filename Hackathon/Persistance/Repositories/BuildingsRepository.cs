using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackathon.Models;
using Hackathon.Repositories;

namespace Hackathon.Persistance.Repositories
{
    public class BuildingsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BuildingsRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<Buildings>> GetAllBuildings()
        {
            return await _dbContext.Buildings.ToListAsync();
        }
    }
}
