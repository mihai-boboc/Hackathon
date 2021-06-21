namespace Hackathon.Abstractions.Services
{
    public interface IPhotoService
    {
        byte[] GetPhoto(string name);
        string SavePhoto(byte[] photo);
        string UpdatePhoto(string oldPhotoName, byte[] photo);
    }

}
