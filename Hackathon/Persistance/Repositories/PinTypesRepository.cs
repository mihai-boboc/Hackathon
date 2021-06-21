using Hackathon.Abstractions.Repositories;
using Hackathon.Models;
using Hackathon.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Persistance.Repositories
{
    public class PinTypesRepository: IPinTypesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PinTypesRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<PinTypes>> GetAllAsync()
        {
            return await _dbContext.PinTypes.ToListAsync();
        }
    }
}
