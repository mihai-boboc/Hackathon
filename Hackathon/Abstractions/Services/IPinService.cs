using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IPinService
    {
        Task<PinsDto> CreatePinAsync(PinsDto pinDto);
        Task<bool> DeletePinAsync(int id);
        Task<List<PinsDto>> GetAllPinsAsync();
        Task<PinsDto> GetPinsByIdAsync(int id);
        Task<List<PinsDto>> GetPinsByTypeAsync(int id);
        Task<PinsDto> UpdatePinAsync(int id, PinsDto pinDto);
    }
}
