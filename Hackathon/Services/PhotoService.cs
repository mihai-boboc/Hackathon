using Hackathon.Abstractions.Services;
using System;

namespace Hackathon.Services
{
    public class PhotoService : IPhotoService
    {
        //TODO: photo saving process
        public string SavePhoto(byte[] photo)
        {
            return new Guid().ToString();
        }

        public string UpdatePhoto(string oldPhotoName, byte[] photo)
        {
            return new Guid().ToString();
        }

        public byte[] GetPhoto(string name)
        {
            return new Guid().ToByteArray();
        }
    }
}
