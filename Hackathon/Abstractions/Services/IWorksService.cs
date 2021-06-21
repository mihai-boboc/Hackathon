using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IWorksService
    {
        Task<WorksDto> CreateWorkAsync(WorksDto worksDto);
        Task<bool> DeleteWorkAsync(int id);
        Task<List<WorksDto>> GetAllWorksAsync();
        Task<WorksDto> GetWorksByIdAsync(int id);
        Task<List<WorksDto>> GetWorksByPinIdAsync(int pinId);
        Task<WorksDto> UpdateWorkAsync(int id, WorksDto worksDto);
    }
}
