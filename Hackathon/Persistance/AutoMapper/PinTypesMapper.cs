using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;

namespace Hackathon.Persistance.AutoMapper
{
    public class PinTypesMapper: Profile
    {
        public PinTypesMapper()
        {
            CreateMap<PinTypesDto, PinTypes>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
