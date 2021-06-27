using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssuesService _issuesService;

        public IssuesController(IIssuesService issuesService)
        {
            _issuesService = issuesService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            var response = await _issuesService.GetAllIssuesAsync();
            return response.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnIssuesById(int id)
        {
            var response = await _issuesService.GetIssuesByIdAsync(id);
            return response.ToActionResult();
        }

        [HttpGet("pin/{id}")]
        public async Task<IActionResult> GetIssuesByPinId(int id)
        {
            var response = await _issuesService.GetIssuesByPinIdAsync(id);
            return response.ToActionResult();
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetIssuesByStatusId(int statusId)
        {
            var response = await _issuesService.GetIssuesByPinStatusIdAsync(statusId);
            return response.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssues(IssuesDto issuesDto)
        {
            var response = await _issuesService.CreateIssuesAsync(issuesDto);
            return response.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssues(int id, IssuesDto issuesDto)
        {
            var response = await _issuesService.UpdateIssuesAsync(id, issuesDto);
            return response.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssues(int id)
        {
            var response = await _issuesService.DeleteIssuesAsync(id);
            return response.ToActionResult();
        }

    }
}
