using Hackathon.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PinTypesController: ControllerBase
    {
        private readonly IPinTypesService _pinTypeService;

        public PinTypesController(IPinTypesService pinTypesService)
        {
            _pinTypeService = pinTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            return Ok(await _pinTypeService.GetAllAsync());
        }
    }
}
