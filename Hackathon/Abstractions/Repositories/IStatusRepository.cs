using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IStatusRepository
    {
        Task<bool> CheckStatus(int id);
        Task<List<Status>> GetAllAsync();
    }
}
