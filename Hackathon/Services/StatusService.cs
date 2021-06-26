using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class StatusService:IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper mapper;

        public StatusService(IStatusRepository statusRepository,
                             IMapper mapper)
        {
            _statusRepository = statusRepository;
            this.mapper = mapper;
        }

        public async Task<Result<List<StatusDto>>> GetAllAsync()
        {
            var statusList = await _statusRepository.GetAllAsync();
            return Result.OK(mapper.Map<List<StatusDto>>(statusList));
        }
    }
}
