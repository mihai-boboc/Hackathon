using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IDepartamentRepository
    {
        Task<List<Departments>> GetAllDepartmentsAsync();
        Task<Departments> GetDepartmentByIdAsync(int id);
        Task<bool> UpdateDepartmentAsync(Departments department);
    }
}
