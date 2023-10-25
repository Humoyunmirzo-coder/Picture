using Aplication.Services;
using Domain.Entity;
using Domain.ModelDTO;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using Picture.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.Infrastructure.Service
{

 
    public  class UserRepository : RepositoryBase<User, long> , IUserRepository
    {
        public UserRepository(DataContexts context) : base(context)
        {
        }

      
    }
}
