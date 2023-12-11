using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAction
{
    public  class TelegramDb : DbContext
    {
        public TelegramDb() { }
        public TelegramDb( DbContextOptions<TelegramDb> options ) : base (options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
