using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface IPhoto : IRepositoryeBase<Photo , Guid>
    {
    }
}
