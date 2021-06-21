using Hackathon.Abstractions.Services;
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
            return Ok(await _issuesService.GetAllIssuesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnIssuesById(int id)
        {
            return Ok(await _issuesService.GetIssuesByIdAsync(id));
        }

        [HttpGet("pin/{id}")]
        public async Task<IActionResult> GetIssuesByPinId(int id)
        {
            return Ok(await _issuesService.GetIssuesByPinIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssues(IssuesDto issuesDto)
        {
            var result = await _issuesService.CreateIssuesAsync(issuesDto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssues(int id, IssuesDto issuesDto)
        {
            var result = await _issuesService.UpdateIssuesAsync(id, issuesDto);
            return result != null ? Ok(result) : Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssues(int id)
        {
            var result = await _issuesService.DeleteIssuesAsync(id);
            return result ? Ok() : BadRequest();
        }

    }
}
