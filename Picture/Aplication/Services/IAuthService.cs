using Domain.Entity;
using Domain.ModelDTO;

namespace Aplication.Services
{
    public interface IAuthService
    {
        public ValueTask<string> LoginAsync(LoginDto dto);
        public ValueTask<User> RegistrationAsync(RegistrationDto dto);
    }
}
