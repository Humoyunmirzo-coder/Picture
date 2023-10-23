using Aplication.Services;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;

namespace Infrastructure.Service
{
    public class PhotoRepostory : RepositoryBase<Photo, Guid>, IPhoto
    {
        public PhotoRepostory(DataContexts context) : base(context)
        {
        }
    {
    }
}
