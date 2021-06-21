using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Data.Common;
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

        public async Task<List<DepartmentsDto>> GetAllDepartmentsAsync()
        {
            var departmentsList = await _departmentsRepository.GetAllDepartmentsAsync();

            var departmentsDtosList = _mapper.Map<List<DepartmentsDto>>(departmentsList);

            return departmentsDtosList;
        }

        public async Task<DepartmentsDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentsRepository.GetDepartmentByIdAsync(id);

            return _mapper.Map<DepartmentsDto>(department);
        }

        public async Task<DepartmentsDto> UpdateDepartmentAsync(int id, DepartmentsDto departmentDto)
        {
            var departmentEntity = await _departmentsRepository.GetDepartmentByIdAsync(id);

            departmentEntity.Name = departmentDto.Name;
            departmentEntity.Email = departmentDto.Email;

            if(await _departmentsRepository.UpdateDepartmentAsync(departmentEntity))
            {
                return _mapper.Map<DepartmentsDto>(departmentEntity);
            }

            return default(DepartmentsDto);
        }
    }
}
