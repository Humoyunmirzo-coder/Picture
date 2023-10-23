using Domain.Entity;
using Domain.ModelDTO;

namespace Aplication.Services
{
    public interface IUserService
    {
        public ValueTask<User> CreateAsync(RegistrationDto dto);
        public ValueTask<User> GetUserByEmailAndPasswordAsync(string password, string email);
    }
}