using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._12._2024_HW
{
    internal class MyDBContext : DbContext
    {
        public DbSet<League> Leagues => Set<League>();
        public DbSet<Player> Players => Set<Player>();

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
    }
}
