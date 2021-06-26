using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class DepartamentsService: IDepartamentService
    {
        private readonly IDepartamentRepository _departmentsRepository;
        private readonly IMapper _mapper;

        public DepartamentsService(IDepartamentRepository departmentsRepository,IMapper mapper)
        {
            _departmentsRepository = departmentsRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<DepartmentsDto>>> GetAllDepartmentsAsync()
        {
            var departmentsList = await _departmentsRepository.GetAllDepartmentsAsync();

            var departmentsDtosList = _mapper.Map<List<DepartmentsDto>>(departmentsList);

            return Result.OK(departmentsDtosList);
        }

        public async Task<Result<DepartmentsDto>> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentsRepository.GetDepartmentByIdAsync(id);
            if(department == null)
            {
                return Result.NotFound<DepartmentsDto>().AddErrors("id", "The id is not valid");
            }

            return Result.OK(_mapper.Map<DepartmentsDto>(department));
        }

        public async Task<Result<DepartmentsDto>> UpdateDepartmentAsync(int id, DepartmentsDto departmentDto)
        {
            var departmentEntity = await _departmentsRepository.GetDepartmentByIdAsync(id);

            if (departmentEntity == null)
            {
                return Result.NotFound<DepartmentsDto>().AddErrors("id", "The id is not valid");
            }

            departmentEntity.Name = departmentDto.Name;
            departmentEntity.Email = departmentDto.Email;

            if(await _departmentsRepository.UpdateDepartmentAsync(departmentEntity))
            {
                return Result.OK(_mapper.Map<DepartmentsDto>(departmentEntity));
            }

            return Result.BadRequest<DepartmentsDto>();
        }
    }
}
