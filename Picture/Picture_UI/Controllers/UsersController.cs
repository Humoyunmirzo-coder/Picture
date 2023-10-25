using Aplication.Services;
using Domain.Entity;
using Domain.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picture.Infrastructure.Interface;

namespace Picture_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet, Authorize]
        public async ValueTask<ApiResult<IEnumerable<User>>> GetAllAsync()
       => ApiResult<User>.FromIEnumerable(await _userRepository.GetAllAsync());

        [HttpGet("{Id:Long}"), Authorize]
        public async ValueTask<ApiResult<User>> GetByIdAsync(long id)
            => await _userRepository.GetByIdAsync(id);

        [HttpDelete, Authorize]
        public async ValueTask<ApiResult<User>> DeleteAsync(long id)
            => await _userRepository.DeleteByIdAsync(id);
    }
}
