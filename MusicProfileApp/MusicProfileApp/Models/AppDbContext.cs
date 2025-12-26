using Microsoft.EntityFrameworkCore;

namespace MusicProfileApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteBand> FavoriteBands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MusicProfileApp.db");
        }
    }
}
