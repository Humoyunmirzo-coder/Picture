using Aplication.Services;
using Domain.Entity;
using Domain.ModelDTO;

namespace Picture.Infrastructure.Interface
{

    public interface IUserRepository : IRepositoryeBase<User, long>
    {
        Task<ApiResult<User>> DeleteAsync(long id);
    }
}