using Domain.Entity;
using Microsoft.AspNetCore.Http;

namespace Aplication.Services
{
    public interface IPhotoService
    {
        public ValueTask<Photo> CreateAsync(IFormFile file, string path, long userId);
        public ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId);
        public ValueTask<Photo> DeleteAsync(string path, Photo photo);
        Task<Photo> CreatAsync(Photo photo);
    }
}