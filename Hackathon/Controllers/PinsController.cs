using Hackathon.Abstractions.Services;
using Hackathon.Common;
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
            var result = await _pinService.GetAllPinsAsync();
            return result.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnPinById(int id)
        {
            var result = await _pinService.GetPinsByIdAsync(id);
            return result.ToActionResult();
        }

        [HttpGet("type/{typeId}")]
        public async Task<IActionResult> ReturnPinByType(int typeId)
        {
            var result = await _pinService.GetPinsByTypeAsync(typeId);
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePin(PinsDto pinsDto)
        {
            var result = await _pinService.CreatePinAsync(pinsDto);
            return result.ToActionResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePin(int id, PinsDto worksDto)
        {
            var result = await _pinService.UpdatePinAsync(id, worksDto);
            return result.ToActionResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePin(int id)
        {
            var result = await _pinService.DeletePinAsync(id);
            return result.ToActionResult();
        }
    }
}
