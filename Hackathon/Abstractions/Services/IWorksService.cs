using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IWorksService
    {
        Task<Result<WorksDto>> CreateWorkAsync(WorksDto worksDto);
        Task<Result<bool>> DeleteWorkAsync(int id);
        Task<Result<List<WorksDto>>> GetAllWorksAsync();
        Task<Result<WorksDto>> GetWorksByIdAsync(int id);
        Task<Result<List<WorksDto>>> GetWorksByPinIdAsync(int pinId);
        Task<Result<WorksDto>> UpdateWorkAsync(int id, WorksDto worksDto);
    }
}
