using Aplication.Services;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.Infrastructure.Service
{


    public  class UserRepository : RepositoryBase<User, long>
    {
        public UserRepository(DataContexts context) : base(context)
        {
        }
    
    }
}
