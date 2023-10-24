using Aplication.Services;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

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
          

            modelBuilder.Entity<Friend>()
                // Ikkinchi aloqa: Friend.Owner va User
                 modelBuilder.Entity<Friend>()
            .HasOne(f=> f.FriendId)
            .WithOne(p => p.Product)
            .HasForeignKey<Warranti>(p => p.Product);

            modelBuilder.Entity<User>()
    // Birinchi aloqa: User va Friend.Friends
    .HasOne(u => u.Friendid) // Friends xususiyatini belgilaymiz
    .WithMany() // Friend sinfidagi Friends xususiyatini beramiz
    .HasForeignKey(u => u.Friendid) // Tashqi kalit xususiyatini belgilaymiz
    .OnDelete(DeleteBehavior.Restrict); // O'chirish harakati uchun siyosatni belgilaymiz


        }
     




    }
}
