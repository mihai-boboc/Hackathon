using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class PinsService : IPinService
    {
        private readonly IPinsRepository _pinsRepository;
        private readonly IPinTypesRepository _pinTypesRepository;
        private readonly IMapper _mapper;

        public PinsService(IPinsRepository pinsRepository, 
                           IPinTypesRepository pinTypesRepository,
                           IMapper mapper)
        {
            _pinsRepository = pinsRepository;
            _pinTypesRepository = pinTypesRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<PinsDto>>> GetAllPinsAsync()
        {
            var pinsList = await _pinsRepository.GetAllPinsAsync();

            return Result.OK(_mapper.Map<List<PinsDto>>(pinsList));
        }

        public async Task<Result<PinsDto>> GetPinsByIdAsync(int id)
        {
            var pin = await _pinsRepository.GetPinByIdAsync(id);

            if (pin == null)
            {
                return Result.NotFound<PinsDto>().AddErrors("id", "The id is not valid");
            }

            return Result.OK(_mapper.Map<PinsDto>(pin));
        }

        public async Task<Result<List<PinsDto>>> GetPinsByTypeAsync(int id)
        {
            var pinsList = await _pinsRepository.GetPinsByType(id);

            if(pinsList == null)
            {
                return Result.BadRequest<List<PinsDto>>().AddErrors("pinId","The pinId is not valid");
            }

            return Result.OK(_mapper.Map<List<PinsDto>>(pinsList));
        }

        public async Task<Result<PinsDto>> CreatePinAsync(PinsDto pinDto)
        {
            var pinEntity = _mapper.Map<Pins>(pinDto);

            if (!await _pinTypesRepository.CheckPinType(pinDto.PinTypeId))
            {
                return Result.BadRequest<PinsDto>().AddErrors("PinTypeId", "PinTypeId is not valid");
            }

            if (await _pinsRepository.CreatePinAsync(pinEntity))
            {
                return Result.OK(_mapper.Map<PinsDto>(pinEntity));
            }
            return Result.InternalServerError<PinsDto>();
        }

        public async Task<Result<PinsDto>> UpdatePinAsync(int id,PinsDto pinDto)
        {
            var pinEntity = await _pinsRepository.GetPinByIdAsync(id);
            var validationCheck = Result.BadRequest<PinsDto>();

            if(pinEntity == null)
            {
                validationCheck.AddErrors("id", "The id is not valid");
            }

            if (!await _pinTypesRepository.CheckPinType(pinDto.PinTypeId))
            {
                validationCheck.AddErrors("PinTypeId", "PinTypeId is not valid");
            }

            if(validationCheck.errors.Count > 0)
            {
                return validationCheck;
            }

            pinEntity.Description = pinDto.Description;
            pinEntity.Name = pinDto.Name;
            pinEntity.GpsCoordX = pinDto.GpsCoordX;
            pinEntity.GpsCoordY = pinDto.GpsCoordY;
            pinEntity.PinTypeId = pinDto.PinTypeId;

            if (await _pinsRepository.UpdatePinAsync(pinEntity))
            {
                return Result.OK(_mapper.Map<PinsDto>(pinEntity));
            }
            return Result.InternalServerError<PinsDto>();
        }

        public async Task<Result<bool>> DeletePinAsync(int id)
        {
            if (await _pinsRepository.DeletePinAsync(id))
            {
                return Result.OK(true);
            }
            return Result.OK(false);
        }
    }
}
