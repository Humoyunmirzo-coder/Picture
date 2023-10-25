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
                .HasOne(f => f.FriendId) // Owner xususiyatini belgilaymiz
                .WithMany(f = ) // Owner xususiyati bir nechta User obyektiga mos kelishi mumkin
                .HasForeignKey(f => f.Owner); // Tashqi kalit xususiyatini belgilaymiz


                modelBuilder.Entity<User>()
    // Birinchi aloqa: User va Friend.Friends
    .HasOne(u => u.Friendid) // Friends xususiyatini belgilaymiz
    .WithMany() // Friend sinfidagi Friends xususiyatini beramiz
    .HasForeignKey(u => u.Friendid) // Tashqi kalit xususiyatini belgilaymiz
    .OnDelete(DeleteBehavior.Restrict); // O'chirish harakati uchun siyosatni belgilaymiz


        }
     




    }
}
