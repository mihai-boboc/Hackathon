using Hackathon.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [Authorize]
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
            var ownerId = User.Claims.FirstOrDefault(c => c.Type.Contains("identity"))?.Value;
            return Ok(await _pinTypeService.GetAllAsync());
        }
    }
}
