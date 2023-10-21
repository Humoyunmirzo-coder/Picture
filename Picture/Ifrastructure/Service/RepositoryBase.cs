using Aplication.Services;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace Ifrastructure.Service
{


    public class RepositoryBase<T, TId> : IRepositoryeBase<T, TId> where T : ModelBase<TId>
    {
        private readonly DataContract _contract;

        public RepositoryBase(DataContract contract)
        {
            _contract = contract;
        }
        public ValueTask<T> CreateAsync(T data)
        {
            throw new NotImplementedException();
        }

        public DbSet<T> DbGetSet()
        {
            throw new NotImplementedException();
        }

        public ValueTask<T> DeleteByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<T> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<T> UpdateAsync(T data)
        {
            throw new NotImplementedException();
        }
    }
}
