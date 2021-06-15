using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IDepartamentService
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
    }
}
