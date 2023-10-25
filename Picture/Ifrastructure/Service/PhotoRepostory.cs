using Aplication.Services;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using Picture.Infrastructure.Interface;

namespace Picture.Infrastructure.Service
{
    public class PhotoRepostory : RepositoryBase<Photo, Guid>, IPhotoRepository
    {
        public PhotoRepostory(DataContexts context) : base(context)
        {
        }

    }
}
