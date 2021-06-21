using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Persistance.AutoMapper
{
    public class StatusMapper: Profile
    {
        public StatusMapper()
        {
            CreateMap<StatusDto, Status>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
