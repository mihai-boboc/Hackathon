using Hackathon.Abstractions.Repositories;
using Hackathon.Models;
using Hackathon.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Persistance.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StatusRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _dbContext.Status.ToListAsync();
        }

        public async Task<bool> CheckStatus(int id)
        {
            return await _dbContext.Status.SingleOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
