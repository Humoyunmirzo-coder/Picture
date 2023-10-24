using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ifrastructure.DataAction
{
    public class DataContexts : DbContext
    {

        public DataContexts() { }

        protected DbSet<User> User { get; set; }
        protected DbSet<Photo> Photos { get; set; }
        protected DbSet<Friend> Friends { get; set; }


        public DataContexts(DbContextOptions<DataContexts> options)
            : base(options)
        {

        }

    }
}
