using Hackathon.Common;
using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IWorksRepository
    {
        Task<bool> CheckWork(int id);
        Task<bool> CreateWorkAsync(Works work);
        Task<bool> DeleteWorkAsync(int id);
        Task<List<Works>> GetAllWorksAsync();
        Task<Works> GetWorksByIdAsync(int id);
        Task<List<Works>> GetWorksByPinIdAsync(int id);
        Task<bool> UpdateWorkAsync(Works work);
    }
}
