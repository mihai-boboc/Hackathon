using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IIssuesService
    {
        Task<Result<IssuesDto>> CreateIssuesAsync(IssuesDto issuesDto);
        Task<Result<bool>> DeleteIssuesAsync(int id);
        Task<Result<List<IssuesDto>>> GetAllIssuesAsync();
        Task<Result<IssuesDto>> GetIssuesByIdAsync(int id);
        Task<Result<List<IssuesDto>>> GetIssuesByPinIdAsync(int pinId);
        Task<Result<List<IssuesDto>>> GetIssuesByPinStatusIdAsync(int statusId);
        Task<Result<IssuesDto>> UpdateIssuesAsync(int id, IssuesDto issuesDto);
    }
}
