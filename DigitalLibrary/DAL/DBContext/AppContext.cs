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
                @"data source=VOVAN-PC\SQLEXPRESS;database=DigitalLibrary;trusted_connection=true");
        }
    }
}
