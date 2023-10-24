using Domain.Entity;
using Domain.ModelDTO;

namespace Picture.Infrastructure.Service.Interface
{
    public interface IUserService 
    {
        public ValueTask<User> CreateAsync(RegistrationDto dto);
        // public  Task GetByIdAsync(long userId);
        public ValueTask<User> GetByIdAsync(long id);
        public ValueTask<User> GetUserByEmailAndPasswordAsync(string password, string email);
    }
}