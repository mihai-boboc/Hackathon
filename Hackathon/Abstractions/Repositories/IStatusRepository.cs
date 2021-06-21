using Hackathon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Repositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
    }
}
