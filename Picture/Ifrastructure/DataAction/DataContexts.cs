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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= ::1 ; Port=5432 ;Database = Picture; User Id = postgres; Password = 2244;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Friend va User sinflari uchun aloqalarni belgilaymiz
            modelBuilder.Entity<Friend>()
                // Birinchi aloqa: Friend.Friends va User
                .HasOne(f => f.Friends) // Friends xususiyatini belgilaymiz
                .WithMany(
                modelBuilder.Entity<Friend>()    // Birinchi aloqa: Friend.Friends va User                     
    .HasOne(f => f.Friends) // Friends xususiyatini belgilaymiz
    .WithMany(u => u.Friendid) // User sinfidagi Friends xususiyatini beramiz
    .HasForeignKey(f => f.FriendId) // Tashqi kalit xususiyatini belgilaymiz
    .OnDelete(DeleteBehavior.Restrict) // O'chirish harakati uchun siyosatni belgilaymiz
                ) // Friends xususiyati bir nechta User obyektiga mos kelishi mumkin
                .HasForeignKey(f => f.FriendId) // Tashqi kalit xususiyatini belgilaymiz
                .OnDelete(DeleteBehavior.Restrict); // O'chirish harakati uchun siyosatni belgilaymiz

            modelBuilder.Entity<Friend>()
                // Ikkinchi aloqa: Friend.Owner va User
                .HasOne(f => f.Owner) // Owner xususiyatini belgilaymiz
                .WithMany() // Owner xususiyati bir nechta User obyektiga mos kelishi mumkin
                .HasForeignKey(f => f.Owner) // Tashqi kalit xususiyatini belgilaymiz
                .OnDelete(DeleteBehavior.Restrict); // O'chirish harakati uchun siyosatni belgilaymiz
        }



    }
}
