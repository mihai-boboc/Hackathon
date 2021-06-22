using Hackathon.Abstractions.Services;
using Hackathon.Models;
using Hackathon.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Hackathon.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoDbContext _photoDbContext;

        public PhotoRepository(PhotoDbContext photoDbContext)
        {
            _photoDbContext = photoDbContext;
        }
        //TODO: photo saving process
        public async Task<Photos> SavePhotoAsync(byte[] photo)
        {

            var photoEntity = new Photos
            {
                Id = new Guid(),
                PhotoByteArray = photo
            };

            await _photoDbContext.Photos.AddAsync(photoEntity);
            await _photoDbContext.SaveChangesAsync();

            return photoEntity;
        }

        public async Task<bool> UpdatePhotoAsync(string id, byte[] photo)
        {
            var photoEntity = await _photoDbContext.Photos.SingleOrDefaultAsync(x => x.Id.ToString() == id);
            photoEntity.PhotoByteArray = photo;

            _photoDbContext.Photos.Update(photoEntity);
            try
            {
                await _photoDbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<Photos> GetPhotoAsync(string id)
        {
            var photoEntity = await _photoDbContext.Photos.SingleOrDefaultAsync(x => x.Id.ToString() == id);
            return photoEntity;
        }

        public async Task<List<Photos>> GetAllPhotosAsync()
        {
            var photoEntity = await _photoDbContext.Photos.ToListAsync();
            return photoEntity;
        }

        public async Task<bool> DeletePhotoAsync(string id)
        {
            var photoEntity = await _photoDbContext.Photos.SingleOrDefaultAsync(x => x.Id.ToString() == id);
            _photoDbContext.Remove(photoEntity);
            try
            {
                await _photoDbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
