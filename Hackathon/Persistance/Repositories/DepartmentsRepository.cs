using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackathon.Models;
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

        public async Task<Departments> GetDepartmentByIdAsync(int id)
        {
            return await _dbContext.Departments.SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<bool> UpdateDepartmentAsync(Departments department)
        {
            _dbContext.Update(department);
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

        public async Task<bool> CheckDepartment(int id)
        {
            return await _dbContext.Departments.SingleOrDefaultAsync(x => x.Id == id) != null ;
        }
    }
}
