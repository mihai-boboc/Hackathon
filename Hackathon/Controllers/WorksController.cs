using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorksController: ControllerBase
    {
        private readonly IWorksService _worksService;

        public WorksController(IWorksService worksService)
        {
            _worksService = worksService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            var result = await _worksService.GetAllWorksAsync();
            return result.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnWorkstById(int id)
        {
            var result = await _worksService.GetWorksByIdAsync(id);
            return result.ToActionResult();
        }

        [HttpGet("pin/{id}")]
        public async Task<IActionResult> GetWorksByPinId(int id)
        {
            var result = await _worksService.GetWorksByPinIdAsync(id);
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorks(WorksDto worksDto)
        {
            var result = await _worksService.CreateWorkAsync(worksDto);
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorks(int id, WorksDto worksDto)
        {
            var result = await _worksService.UpdateWorkAsync(id, worksDto);
            return result.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorks(int id)
        {
            var result = await _worksService.DeleteWorkAsync(id);
            return result.ToActionResult();
        }
    }
}
