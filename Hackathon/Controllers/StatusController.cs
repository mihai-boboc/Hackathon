using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController:ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            var result = await _statusService.GetAllAsync();
            return result.ToActionResult();
        }
    }
}
