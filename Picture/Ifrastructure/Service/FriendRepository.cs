using Aplication.Services;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;

namespace Infrastructure.Service
{
    public class FriendRepository : RepositoryBase<Friend, long>, Ifriends
    {
        public FriendRepository(DataContexts dataContexts) : base(dataContexts)
        { }
    }
}
