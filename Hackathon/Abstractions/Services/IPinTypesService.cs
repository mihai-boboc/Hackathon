using Hackathon.Common;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IPinTypesService
    {
        Task<Result<List<PinTypesDto>>> GetAllAsync();
    }
}
