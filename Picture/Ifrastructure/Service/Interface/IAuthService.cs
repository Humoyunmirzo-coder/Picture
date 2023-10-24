using Domain.Entity;
using Domain.ModelDTO;

namespace Picture.Infrastructure.Service.Interface
{
    public interface IAuthService
    {
        public ValueTask<string> LoginAsync(LoginDto dto);
        public ValueTask<User> RegistrationAsync(RegistrationDto dto);
    }
}
