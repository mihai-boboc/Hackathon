using Hackathon.Abstractions.Repositories;
using Hackathon.Models;
using Hackathon.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Persistance.Repositories
{
    public class IssuesRepository : IIssuesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IssuesRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<Issues>> GetAllIssuesAsync()
        {
            return await _dbContext.Issues.ToListAsync();
        }

        public async Task<Issues> GetIssuesByIdAsync(int id)
        {
            return await _dbContext.Issues.SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Issues>> GetIssuesByStatusAsync(int statusId)
        {
            return await _dbContext.Issues.Where(x => x.StatusId == statusId).ToListAsync();
        }

        public async Task<List<Issues>> GetIssuesByPinIdAsync(int id)
        {
            return await _dbContext.Issues.Where(x => x.PinId == id).ToListAsync();
        }

        public async Task<bool> CreateIssuesAsync(Issues issue)
        {
            await _dbContext.Issues.AddAsync(issue);
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

        public async Task<bool> UpdateIssuesAsync(Issues issue)
        {
            _dbContext.Update(issue);
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

        public async Task<bool> DeleteIssuesAsync(int id)
        {
            var work = await _dbContext.Issues.SingleOrDefaultAsync(x => x.Id == id);
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
    }
}
