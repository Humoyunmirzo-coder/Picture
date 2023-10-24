using Aplication.Services;
using Domain.Entity;
using Domain.Exceptions;
using Domain.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picture.Infrastructure.Interface;
using Picture.Infrastructure.Service.Interface;

namespace Picture_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        public readonly IPhotoService _photoService;
        public readonly IPhotoRepository _photoRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        // public readonly ILogger _logger;
        public PhotosController(IPhotoService photoService, IPhotoRepository photoRepository, 
            IWebHostEnvironment webHostEnvironment)
        {
            _photoService = photoService;
            _photoRepository = photoRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost, Authorize]
        public async ValueTask<ApiResult<Photo>> CreateAsync(IFormFile file, long userId)
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), webRootPath, "Photos");

            return await _photoService.CreateAsync(file, filePath, userId);
        }

        [HttpGet("{Id:Long}"), Authorize]
        public async ValueTask<ApiResult<IEnumerable<Photo>>> GetPhotoByUserIdAsync(long id)
        {
            return ApiResult<Photo>.FromIEnumerable(await _photoService.GetPhotoByUserIdAsync(id));
        }

        [HttpDelete("{Id:Guid}"), Authorize]
        public async ValueTask<ApiResult<Photo>> DeleteAsync(Guid id)
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), webRootPath, "Photos");
            var photo = await _photoRepository.GetByIdAsync(id);
            if (photo is null)
                throw new CustomException(404, "Photo not found");
            var result = await _photoService.DeleteAsync(filePath, photo);
            return result;
        }
    }
}
