using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hackathon.Abstractions.Services;
using Hackathon.Models.DTOs;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartamentService _departamentsService;

        public DepartmentsController(IDepartamentService departamentsService)
        {
            _departamentsService = departamentsService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            return Ok(await _departamentsService.GetAllDepartmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnDepartmentById(int id)
        {
            return Ok(await _departamentsService.GetDepartmentByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentsDto departamentsDto)
        {
            var updatedDepartment = await _departamentsService.UpdateDepartmentAsync(id, departamentsDto);
            return updatedDepartment != null ? Ok(updatedDepartment) : Conflict();
        }

    }
}
