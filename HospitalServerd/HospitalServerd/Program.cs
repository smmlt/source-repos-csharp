using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HospitalServerd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=HospitalServer;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True";
            using (var context = new HospitalContext(connectionString))
            {
                // Создаём нового пациента
                var patient = new Patient
                {
                    FullName = "Иван Иванов",
                    BirthDate = new DateTime(1990, 1, 1),
                    Symptoms = "Боль в животе"
                };

                // Добавляем пациента в базу
                context.Patients.Add(patient);
                context.SaveChanges();

                // Создаём запись на приём
                var appointment = new Appointment
                {
                    Date = new DateTime(2025, 3, 5),
                    Time = new TimeSpan(10, 0, 0),  // 10:00 AM
                    Department = "Терапия",
                    PatientId = patient.Id
                };

                // Добавляем приём в базу
                context.Appointments.Add(appointment);
                context.SaveChanges();

                Console.WriteLine("Данные успешно добавлены в базу!");
            }
        }
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

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Department { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Symptoms { get; set; }
    }
}
