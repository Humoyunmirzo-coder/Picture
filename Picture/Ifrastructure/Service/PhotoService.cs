using Aplication.Services;
using Aplication.Servicess;
using Domain;
using Domain.Entity;
using Domain.Enum;
using Domain.Exceptions;
using Domain.ModelDTO;
using Ifrastructure.DataAction;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PictureSharing.Services.Interface;
using ServiceStack;

namespace Ifrastructure.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoService _photoRepository;
        private readonly IUserService _userRepository;

        public PhotoService(IPhotoService photoRepository, IUserService userRepository)
        {
            _photoRepository = photoRepository;
            _userRepository = userRepository;
        }

        public async ValueTask<Photo> CreateAsync(IFormFile file, string filePath, long userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                throw new CustomException(404, "User not found");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var photo = await _photoRepository.CreatAsync(new Photo
            {
                Name = file.FileName,
                UserId = userId
            });

            filePath = Path.Combine(filePath, photo.Id.ToString());
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return photo;
        }

        public async ValueTask<IEnumerable<Photo>> GetPhotoByUserIdAsync(long userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                throw new CustomException(404, "User not found");
            return null; //user.Photos;
        }

        public async ValueTask<Photo> DeleteAsync(string path, Photo photo)
        {
            string filePath = Path.Combine(path, photo.Id.ToString());
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new CustomException(404, "file not found");
            }

            photo = await _photoRepository.DeleteAsync( filePath  , photo  );
             
            return photo;
        }

        ValueTask<Photo> IPhotoService.CreateAsync(IFormFile file, string path, long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Photo> CreatAsync(Photo photo )
        {
            return photo;
        
        }
    }
}