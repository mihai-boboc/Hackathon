using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IPinService
    {
        Task<Result<PinsDto>> CreatePinAsync(PinsDto pinDto);
        Task<Result<bool>> DeletePinAsync(int id);
        Task<Result<List<PinsDto>>> GetAllPinsAsync();
        Task<Result<PinsDto>> GetPinsByIdAsync(int id);
        Task<Result<List<PinsDto>>> GetPinsByTypeAsync(int id);
        Task<Result<PinsDto>> UpdatePinAsync(int id, PinsDto pinDto);
    }
}
