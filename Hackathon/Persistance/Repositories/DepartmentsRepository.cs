using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackathon.Models;
using Hackathon.Repositories;
using Hackathon.Abstractions.Repositories;

namespace Hackathon.Repositories
{
    public class DepartmentsRepository: IDepartamentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentsRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }

        public async Task<List<Departments>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
