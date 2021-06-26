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
        private readonly IMapper _mapper;

        public WorksService(IWorksRepository worksRepository, IMapper mapper)
        {
            _worksRepository = worksRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<WorksDto>>> GetAllWorksAsync()
        {
            var worksList =  await _worksRepository.GetAllWorksAsync();
            return Result.OK(_mapper.Map<List<WorksDto>>(worksList));
        }

        public async Task<Result<WorksDto>> GetWorksByIdAsync(int id)
        {
            var works = await _worksRepository.GetWorksByIdAsync(id);
            return Result.OK(_mapper.Map<WorksDto>(works));
        }

        public async Task<Result<List<WorksDto>>> GetWorksByPinIdAsync(int pinId)
        {
            var worksList = await _worksRepository.GetWorksByPinIdAsync(pinId);
            return Result.OK(_mapper.Map<List<WorksDto>>(worksList));
        }

        public async Task<Result<WorksDto>> CreateWorkAsync(WorksDto worksDto)
        {
            var workEntity = _mapper.Map<Works>(worksDto);
            if(await _worksRepository.CreateWorkAsync(workEntity))
            {
                return Result.OK(_mapper.Map<WorksDto>(workEntity));
            }
            return Result.InternalServerError<WorksDto>();
        }

        public async Task<Result<WorksDto>> UpdateWorkAsync(int id, WorksDto worksDto)
        {
            var workEntity = await _worksRepository.GetWorksByIdAsync(id);

            if(workEntity == null)
            {
                return Result.NotFound<WorksDto>().AddErrors("id", "The id is not valid");
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
