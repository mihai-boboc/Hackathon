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
    public class WorksMapper:Profile
    {
        public WorksMapper()
        {
            CreateMap<WorksDto, Works>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
