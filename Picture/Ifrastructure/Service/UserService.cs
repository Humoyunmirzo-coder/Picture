using Aplication.Services;
using Domain.Entity;
using Domain.Exceptions;
using Domain.ModelDTO;
using ServiceStack.Auth;
using Domain;
using Microsoft.EntityFrameworkCore;
using Picture.Infrastructure.Service.Interface;
using Picture.Infrastructure.Interface;

namespace Picture.Infrastructure.Service
{
    public class UserService : IUserService
    {

        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async ValueTask<User> CreateAsync(RegistrationDto dto)
        {
            if (dto is null)
                throw new CustomException(400, "Bad request dto null");
            User user = new User
            {
                Password = dto.Password,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname
            };
            return await _userRepository.CreateAsync(user);
        }

        public ValueTask<User> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<User> GetUserByEmailAndPasswordAsync(string password, string email)
        {
            var user = _userRepository.DbGetSet()
                                      .FirstOrDefault(user => user.Email == email && user.Password == password);
            if (user is null)
                throw new CustomException(404, "Not found");
            return user;
        }

        ValueTask<User> IUserService.GetUserByEmailAndPasswordAsync(string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}