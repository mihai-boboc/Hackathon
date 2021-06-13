using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Persistance.Repositories;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
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
