using Aplication.Services;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using Picture.Infrastructure.Interface;

namespace Picture.Infrastructure.Service
{
    public class FriendRepository : RepositoryBase<Friend, long>, IFriendRepository
    {
        public FriendRepository(DataContexts dataContexts) : base(dataContexts)
        { }
    }
}
