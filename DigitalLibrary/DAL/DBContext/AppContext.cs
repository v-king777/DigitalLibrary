using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=[имя сервера];database=[имя базы];trusted_connection=true");
        }
    }
}
