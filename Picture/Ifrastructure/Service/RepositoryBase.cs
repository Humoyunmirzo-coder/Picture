using Aplication.Services;
using Domain;
using Domain.Exceptions;
using Ifrastructure.DataAction;
using Microsoft.EntityFrameworkCore;

namespace Ifrastructure.Service
{
    public class RepositoryBase<T, TId> : IRepositoryeBase<T, TId> where T : ModelBase<TId>
    {
        private readonly DataContexts _contract;

        public RepositoryBase(DataContexts contract)
        {
            _contract = contract;
        }



        public async ValueTask<T> CreateAsync(T data)
        {
            var result = DbGetSet().Add(data);
            _contract.SaveChanges();
            return result.Entity;
        }

        public DbSet<T> DbGetSet()
        {
            return _contract.Set<T>();
        }

        public async ValueTask<T> DeleteByIdAsync(TId id)
        {
            var data = await GetByIdAsync(id);
            var entityResult = DbGetSet().Remove(data);
            await _contract.SaveChangesAsync();
            return entityResult.Entity;
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync()
        {
            return await DbGetSet().ToListAsync();
        }

        public async ValueTask<T> GetByIdAsync(TId id)
        {
            var data = await DbGetSet().FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (data is null)
                throw new CustomException(404, "Data not found ");
            return data;

        }

        public async ValueTask<T> UpdateAsync(T data)
        {
            var resultUpdate = DbGetSet().Update(data);
            await _contract.SaveChangesAsync();
            return resultUpdate.Entity;
        }

    }
}
