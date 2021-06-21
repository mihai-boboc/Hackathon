using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IPinTypesRepository
    {
        Task<List<PinTypes>> GetAllAsync();
    }
}
