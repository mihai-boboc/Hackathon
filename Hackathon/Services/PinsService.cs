using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class PinsService : IPinService
    {
        private readonly IPinsRepository _pinsRepository;
        private readonly IMapper _mapper;

        public PinsService(IPinsRepository pinsRepository, IMapper mapper)
        {
            _pinsRepository = pinsRepository;
            _mapper = mapper;
        }

        public async Task<List<PinsDto>> GetAllPinsAsync()
        {
            var pinsList = await _pinsRepository.GetAllPinsAsync();

            return _mapper.Map<List<PinsDto>>(pinsList);
        }

        public async Task<PinsDto> GetPinsByIdAsync(int id)
        {
            var pin = await _pinsRepository.GetPinByIdAsync(id);

            return _mapper.Map<PinsDto>(pin);
        }

        public async Task<List<PinsDto>> GetPinsByTypeAsync(int id)
        {
            var pinsList = await _pinsRepository.GetPinsByType(id);

            return _mapper.Map<List<PinsDto>>(pinsList);
        }

        public async Task<PinsDto> CreatePinAsync(PinsDto pinDto)
        {
            var pinEntity = _mapper.Map<Pins>(pinDto);
            if (await _pinsRepository.CreatePinAsync(pinEntity))
            {
                return _mapper.Map<PinsDto>(pinEntity);
            }
            return default(PinsDto);
        }

        public async Task<PinsDto> UpdatePinAsync(int id,PinsDto pinDto)
        {
            var pinEntity = await _pinsRepository.GetPinByIdAsync(id);

            pinEntity.Description = pinDto.Description;
            pinEntity.GpsCoordX = pinDto.GpsCoordX;
            pinEntity.GpsCoordY = pinDto.GpsCoordY;
            pinEntity.PinTypeId = pinDto.PinTypeId;

            if (await _pinsRepository.UpdatePinAsync(pinEntity))
            {
                return _mapper.Map<PinsDto>(pinEntity);
            }
            return default(PinsDto);
        }

        public async Task<bool> DeletePinAsync(int id)
        {
            if (await _pinsRepository.DeletePinAsync(id))
            {
                return true;
            }
            return false;
        }
    }
}
