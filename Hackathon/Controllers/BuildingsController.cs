using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Hackathon.Persistance.Repositories;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly BuildingsRepository _buildingsRepository;

        public BuildingsController(ILogger<BuildingsController> logger, BuildingsRepository buildingsRepository)
        {
            _buildingsRepository = buildingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            return Ok(await _buildingsRepository.GetAllBuildings());
        }

    }
}
