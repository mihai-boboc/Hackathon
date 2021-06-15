using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
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

        public async Task<List<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departmentsList = await _departmentsRepository.GetAllDepartmentsAsync();

            var departmentsDtosList = _mapper.Map<List<DepartmentDto>>(departmentsList);

            return departmentsDtosList;
        }
    }
}
