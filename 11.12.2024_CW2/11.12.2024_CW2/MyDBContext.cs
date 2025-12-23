using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._12._2024_CW2
{
    internal class MyDBContext : DbContext
    {
        public DbSet<LogIn> Logins => Set<LogIn>();
        public DbSet<User> Users => Set<User>();
        public DbSet<MusicGroup> MusicGroups => Set<MusicGroup>();

        string connectString;
        public MyDBContext(string connectString)
        {
            this.connectString = connectString;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.LogIn)
                .WithOne(l => l.ThisUser)
                .HasForeignKey<User>(u => u.LogInId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
