using Hackathon.Abstractions.Repositories;
using Hackathon.Models;
using Hackathon.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Persistance.Repositories
{
    public class PinsRepository : IPinsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PinsRepository(ApplicationDbContext dBcontext)
        {
            _dbContext = dBcontext;
        }
        public async Task<List<Pins>> GetAllPinsAsync()
        {
            return await _dbContext.Pins.ToListAsync();
        }

        public async Task<Pins> GetPinByIdAsync(int id)
        {
            return await _dbContext.Pins.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pins>> GetPinsByType(int pinTypeId)
        {
            return await _dbContext.Pins.Where(x => x.PinTypeId == pinTypeId).ToListAsync();
        }

        public async Task<bool> CreatePinAsync(Pins pin)
        {
            _dbContext.Pins.Add(pin);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdatePinAsync(Pins pin)
        {
            _dbContext.Update(pin);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeletePinAsync(int id)
        {
            var pin = await _dbContext.Pins.SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Pins.Remove(pin);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
