using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;

namespace Hackathon.Persistance.AutoMapper
{
    public class DepartmentsMapper : Profile
    {
        public DepartmentsMapper()
        {
            CreateMap<DepartmentsDto, Departments>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
