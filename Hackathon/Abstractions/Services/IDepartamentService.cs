using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IDepartamentService
    {
        Task<Result<List<DepartmentsDto>>> GetAllDepartmentsAsync();
        Task<Result<DepartmentsDto>> GetDepartmentByIdAsync(int id);
        Task<Result<DepartmentsDto>> UpdateDepartmentAsync(int id, DepartmentsDto departmentDto);
    }
}
