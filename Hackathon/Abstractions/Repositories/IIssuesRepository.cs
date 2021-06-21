using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IIssuesRepository
    {
        Task<bool> CreateIssuesAsync(Issues issue);
        Task<bool> DeleteIssuesAsync(int id);
        Task<List<Issues>> GetAllIssuesAsync();
        Task<Issues> GetIssuesByIdAsync(int id);
        Task<List<Issues>> GetIssuesByPinIdAsync(int id);
        Task<bool> UpdateIssuesAsync(Issues issue);
    }
}
