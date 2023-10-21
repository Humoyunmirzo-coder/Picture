using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface IRepositoryeBase <T , TId>  where T : ModelBase<TId>
    {
        public DbSet<T> DbGetSet();
        public ValueTask< IEnumerable<T>> GetAllAsync();
        public ValueTask <T> GetByIdAsync(TId id);
        public ValueTask <T> CreateAsync(T data);
        public ValueTask<T> UpdateAsync(T data);
        public ValueTask<T> DeleteByIdAsync(TId id);


    }
}
