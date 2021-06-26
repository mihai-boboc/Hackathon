using Hackathon.Abstractions.Repositories;
using Hackathon.Common;
using Hackathon.Models;
using Hackathon.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Persistance.Repositories
{
    public class WorksRepository:IWorksRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WorksRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<Works>> GetAllWorksAsync()
        {
            return await _dbContext.Works.ToListAsync();
        }

        public async Task<Works> GetWorksByIdAsync(int id)
        {
            return await _dbContext.Works.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Works>> GetWorksByPinIdAsync(int id)
        {
            return await _dbContext.Works.Where(x => x.PinId == id).ToListAsync();
        }

        public async Task<bool> CreateWorkAsync(Works work)
        {
            await _dbContext.Works.AddAsync(work);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateWorkAsync(Works work)
        {
            _dbContext.Update(work);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteWorkAsync(int id)
        {
            var work = await _dbContext.Works.SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Remove(work);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckWork(int id)
        {
            return await _dbContext.Works.SingleOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
