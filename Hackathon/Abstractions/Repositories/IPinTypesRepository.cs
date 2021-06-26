using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IPinTypesRepository
    {
        Task<bool> CheckPinType(int id);
        Task<List<PinTypes>> GetAllAsync();
    }
}
