using Aplication.Services;
using Domain.Entity;

namespace Picture.Infrastructure.Interface
{

    public interface IPhotoRepository : IRepositoryeBase<Photo, Guid>
    {

    }
}