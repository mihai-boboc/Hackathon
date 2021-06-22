using Hackathon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Abstractions.Services
{
    public interface IPhotoRepository
    {
        Task<bool> DeletePhotoAsync(string id);
        Task<List<Photos>> GetAllPhotosAsync();
        Task<Photos> GetPhotoAsync(string id);
        Task<Photos> SavePhotoAsync(byte[] photo);
        Task<bool> UpdatePhotoAsync(string id, byte[] photo);
    }

}
