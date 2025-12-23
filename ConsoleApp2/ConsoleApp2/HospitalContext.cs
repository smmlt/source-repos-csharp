using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        string connectionString = @"Server=localhost\SQLEXPRESS;
                                        Database=HospitalServer;
                                        Trusted_Connection=True;
                                        Encrypt=False;
                                        TrustServerCertificate=True";

        public HospitalContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        //public HospitalContext()
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
        }

    }
}
