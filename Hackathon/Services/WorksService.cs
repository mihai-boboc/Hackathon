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
    public class WorksService:IWorksService
    {
        private readonly IWorksRepository _worksRepository;
        private readonly IPinsRepository _pinsRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public WorksService(IWorksRepository worksRepository,
                            IPinsRepository pinsRepository,
                            IStatusRepository statusRepository,
                            IMapper mapper)
        {
            _worksRepository = worksRepository;
            _pinsRepository = pinsRepository;
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<WorksDto>>> GetAllWorksAsync()
        {
            var worksList =  await _worksRepository.GetAllWorksAsync();
            return Result.OK(_mapper.Map<List<WorksDto>>(worksList));
        }

        public async Task<Result<WorksDto>> GetWorksByIdAsync(int id)
        {
            var workEntity = await _worksRepository.GetWorksByIdAsync(id);

            if (workEntity == null)
            {
                return Result.NotFound<WorksDto>().AddErrors("id", "The id is not valid");
            }
            return Result.OK(_mapper.Map<WorksDto>(workEntity));
        }

        public async Task<Result<List<WorksDto>>> GetWorksByPinIdAsync(int pinId)
        {
            var worksList = await _worksRepository.GetWorksByPinIdAsync(pinId);
            if (worksList == null)
            {
                return Result.NotFound<List<WorksDto>>().AddErrors("pinId", "The pinId is not valid");
            }

            return Result.OK(_mapper.Map<List<WorksDto>>(worksList));
        }

        public async Task<Result<WorksDto>> CreateWorkAsync(WorksDto worksDto)
        {

            var validationTest = Result.BadRequest<WorksDto>();

            if (!await _pinsRepository.CheckPin(worksDto.PinId))
            {
                validationTest.AddErrors("PinId", "PinId is not valid");
            }

            if (!await _statusRepository.CheckStatus(worksDto.StatusId))
            {
                validationTest.AddErrors("StatusId", "StatusId is not valid");
            }

            if (validationTest.errors.Count > 0)
            {
                return validationTest;
            }

            var workEntity = _mapper.Map<Works>(worksDto);

            if (await _worksRepository.CreateWorkAsync(workEntity))
            {
                return Result.OK(_mapper.Map<WorksDto>(workEntity));
            }
            return Result.BadRequest<WorksDto>();
        }

        public async Task<Result<WorksDto>> UpdateWorkAsync(int id, WorksDto worksDto)
        {
            var workEntity = await _worksRepository.GetWorksByIdAsync(id);
            var validationTest = Result.BadRequest<WorksDto>();

            if(workEntity == null)
            {
                validationTest.AddErrors("id", "The id is not valid");
            }

            if (!await _pinsRepository.CheckPin(worksDto.PinId))
            {
                validationTest.AddErrors("PinId", "PinId is not valid");
            }

            if (!await _statusRepository.CheckStatus(worksDto.StatusId))
            {
                validationTest.AddErrors("StatusId", "StatusId is not valid");
            }

            if(validationTest.errors.Count > 0)
            {
                return validationTest;
            }

            workEntity.Details = worksDto.Details;
            workEntity.DepartmentId = worksDto.DepartmentId;
            workEntity.PinId = worksDto.PinId;
            workEntity.StatusId = worksDto.StatusId;

            if (await _worksRepository.UpdateWorkAsync(workEntity))
            {
                return Result.OK(_mapper.Map<WorksDto>(workEntity));
            }
            return Result.InternalServerError<WorksDto>();
        }

        public async Task<Result<bool>> DeleteWorkAsync(int id)
        {
            if (await _worksRepository.DeleteWorkAsync(id))
            {
                return Result.OK(true);
            }
            return Result.InternalServerError<bool>() ;
        }
    }
}
