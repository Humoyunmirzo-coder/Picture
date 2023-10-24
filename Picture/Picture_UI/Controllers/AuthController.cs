using Aplication.Services;
using Domain.Entity;
using Domain.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picture.Infrastructure.Service.Interface;

namespace Picture_UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login"), AllowAnonymous]
        public async ValueTask<string> LoginAsync(LoginDto dto)
        {
            return await _authService.LoginAsync(dto);
        }

        [HttpPost("registration"), AllowAnonymous]
        public async ValueTask<ApiResult<User>> RegistrationAsync(RegistrationDto dto)
        {
            return await _authService.RegistrationAsync(dto);
        }
    }
}
