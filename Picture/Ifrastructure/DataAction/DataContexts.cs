using Aplication.Services;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ServiceStack;
using System.Text;
using System.Xml.Linq;
using System;
using System.Collections.Specialized;
using System.Configuration;


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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= ::1 ; Port=5432 ;Database = Picture; User Id = postgres; Password = 2244;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(photo => photo.Photos)
                .WithOne(user =>user.User)
                .HasForeignKey(us=>us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<User>()   
                .HasMany(frinend =>frinend.Friends)
                .WithOne(user =>user.Owner)
                .HasForeignKey(us=>us.Userid)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

    
}
