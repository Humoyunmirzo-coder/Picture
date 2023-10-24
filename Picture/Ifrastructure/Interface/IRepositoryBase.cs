using Aplication.Services;
using Domain;
using Domain.Entity;
using Ifrastructure.DataAction;
using Ifrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace Picture.Infrastructure.Interface
{
    public interface IRepositoryBase<T, TId> where T : ModelBase<TId>
    {
        public DbSet<T> DbGetSet();
        public ValueTask<IEnumerable<T>> GetAllAsync();
        public ValueTask<T> GetByIdAsync(TId id);
        public ValueTask<T> CreatAsync(T data);
        public ValueTask<T> UpdateAsync(T data);
        public ValueTask<T> DeleteAsync(TId id);
    }
}