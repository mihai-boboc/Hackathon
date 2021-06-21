using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IIssuesService
    {
        Task<IssuesDto> CreateIssuesAsync(IssuesDto issuesDto);
        Task<bool> DeleteIssuesAsync(int id);
        Task<List<IssuesDto>> GetAllIssuesAsync();
        Task<IssuesDto> GetIssuesByIdAsync(int id);
        Task<List<IssuesDto>> GetIssuesByPinIdAsync(int pinId);
        Task<IssuesDto> UpdateIssuesAsync(int id, IssuesDto issuesDto);
    }
}
