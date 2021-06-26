using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class PinTypesService: IPinTypesService
    {
        private readonly IPinTypesRepository _pinTypesRepository;
        private readonly IMapper _mapper;

        public PinTypesService(IPinTypesRepository pinTypesRepository, IMapper mapper)
        {
            _pinTypesRepository = pinTypesRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<PinTypesDto>>> GetAllAsync()
        {
            var pinTypesList = await _pinTypesRepository.GetAllAsync();

            return Result.OK(_mapper.Map<List<PinTypesDto>>(pinTypesList));

        }
    }
}
