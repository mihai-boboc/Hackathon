using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Persistance.Repositories
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
