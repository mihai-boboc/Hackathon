using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IPinsRepository
    {
        Task<bool> CreatePinAsync(Pins pin);
        Task<bool> DeletePinAsync(int id);
        Task<List<Pins>> GetAllPinsAsync();
        Task<Pins> GetPinByIdAsync(int id);
        Task<List<Pins>> GetPinsByType(int pinTypeId);
        Task<bool> UpdatePinAsync(Pins pin);
    }
}
