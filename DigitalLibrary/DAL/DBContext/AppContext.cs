using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=[имя_сервера];database=[имя_БД];trusted_connection=true");
        }
    }
}
