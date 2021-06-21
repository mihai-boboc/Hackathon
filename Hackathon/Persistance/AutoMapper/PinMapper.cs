using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;

namespace Hackathon.Persistance.AutoMapper
{
    public class PinMapper:Profile
    {
        public PinMapper()
        {
            CreateMap<PinsDto, Pins>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
