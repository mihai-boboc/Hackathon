using Hackathon.Abstractions.Services;
using Hackathon.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return Ok(await _worksService.GetAllWorksAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnWorkstById(int id)
        {
            return Ok(await _worksService.GetWorksByIdAsync(id));
        }

        [HttpGet("pin/{id}")]
        public async Task<IActionResult> GetWorksByPinId(int id)
        {
            return Ok(await _worksService.GetWorksByPinIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorks(WorksDto worksDto)
        {
            var result = await _worksService.CreateWorkAsync(worksDto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorks(int id, WorksDto worksDto)
        {
            var result = await _worksService.UpdateWorkAsync(id, worksDto);
            return result != null ? Ok(result) : Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateWorks(int id)
        {
            var result = await _worksService.DeleteWorkAsync(id);
            return result ? Ok() : BadRequest();
        }
    }
}
