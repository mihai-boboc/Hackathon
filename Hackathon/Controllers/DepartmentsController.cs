using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hackathon.Abstractions.Services;

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

    }
}
