using Hackathon.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IStatusService
    {
        Task<List<StatusDto>> GetAllAsync();
    }
}
