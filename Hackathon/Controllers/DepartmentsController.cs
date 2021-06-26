using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hackathon.Abstractions.Services;
using Hackathon.Models.DTOs;
using Hackathon.Common;

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
            var response = await _departamentsService.GetAllDepartmentsAsync();
            return response.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnDepartmentById(int id)
        {
            var response = await _departamentsService.GetDepartmentByIdAsync(id);
            return response.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentsDto departamentsDto)
        {
            var updatedDepartment = await _departamentsService.UpdateDepartmentAsync(id, departamentsDto);
            return updatedDepartment.ToActionResult();
        }

    }
}
