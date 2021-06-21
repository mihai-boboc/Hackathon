using Hackathon.Abstractions.Services;
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
            return Ok(await _statusService.GetAllAsync());
        }
    }
}
