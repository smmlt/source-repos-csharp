using Microsoft.EntityFrameworkCore;

namespace _04._12._2024
{
    class Doctor
    {
        public int          id {  get; set; }
        public string?      Name { get; set; }
        public decimal?     Premium { get; set; }
        public decimal?     Salary { get; set; }
        public string?      Surname { get; set; }

        public override string ToString() => $"{Name} | {Premium} | {Salary} | {Surname}";
            
        
    }

    class MyDatabaseContex : DbContext
    {
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public MyDatabaseContex() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;
                                          Database=TestDoctor;
                                          Trusted_Connection=True;
                                          Encrypt=False;
                                          TrustServerCertificate=True");
        }       
    }

    internal class Program
    {
        static void ShowAll(MyDatabaseContex db)
        {
            var doctors = db.Doctors.ToList();

            foreach (var dc in doctors)
            {
                Console.WriteLine(dc);
            }
        }
        static void Main(string[] args)
        {
            
            using (var db = new MyDatabaseContex())
            {
                // С - добавить запись
                db.Doctors.Add(new Doctor() { Name = "Jack", Salary = new Random().Next(1232, 12000) });
                db.SaveChanges();

                // R - прочитать записи
                ShowAll(db);

                // U - обновить запись
                Doctor? dc = db.Doctors.FirstOrDefault(x => x.Salary > 4700);
                if (dc != null)
                {
                    dc.Name = "Oleg";
                    db.SaveChanges();
                }
                ShowAll(db);

                // R - удалить запись
                Doctor? dc2 = db.Doctors.FirstOrDefault(x => x.Salary > 5000);
                if (dc2 != null)
                {
                    db.Doctors.Remove(dc2);
                    db.SaveChanges();
                }
                ShowAll(db);
            }
        }
    }
}
