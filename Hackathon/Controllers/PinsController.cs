using Hackathon.Abstractions.Services;
using Hackathon.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PinsController: ControllerBase
    {
        private readonly IPinService _pinService;

        public PinsController(IPinService pinService)
        {
            _pinService = pinService;
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAll()
        {
            return Ok(await _pinService.GetAllPinsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnPinById(int id)
        {
            return Ok(await _pinService.GetPinsByIdAsync(id));
        }

        [HttpGet("type/{typeId}")]
        public async Task<IActionResult> ReturnPinByType(int typeId)
        {
            return Ok(await _pinService.GetPinsByTypeAsync(typeId));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePin(PinsDto pinsDto)
        {
            var result = await _pinService.CreatePinAsync(pinsDto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePin(int id, PinsDto worksDto)
        {
            var result = await _pinService.UpdatePinAsync(id, worksDto);
            return result != null ? Ok(result) : Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePin(int id)
        {
            var result = await _pinService.DeletePinAsync(id);
            return result ? Ok() : BadRequest();
        }
    }
}
