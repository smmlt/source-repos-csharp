using Microsoft.Data.SqlClient;

namespace _20._11_CW
{
    internal class Program
    {
        class Student
        {
            public string? FullName { get; set; }
            public string? GroupName { get; set; }
            public decimal? AverageGrade { get; set; }
            public string? MinSubject { get; set; }
            public string? MaxSubject { get; set; }
        }

        class ElectronicJournalManager : IDisposable
        {
            string connectionData = @"Server=localhost\SQLEXPRESS;
                                   Database=ElectronicJournal;
                                   Trusted_Connection=True;
                                   Encrypt=False;
                                   TrustServerCertificate=True";
            SqlConnection connection;

            public ElectronicJournalManager()
            {
                connection = new SqlConnection(connectionData);
                connection.Open();
                Console.WriteLine("Connected to ElectronicJournal database");
            }

            public void Dispose()
            {
                connection.Close();
                Console.WriteLine("Connection closed");
            }

            public void InsertStudent(Student student)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Students VALUES (@fullName, @groupName, @averageGrade, @minSubject, @maxSubject)",
                    connection);

                cmd.Parameters.Add(new SqlParameter("@fullName",     student.FullName));
                cmd.Parameters.Add(new SqlParameter("@groupName",    (object?)student.GroupName ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@averageGrade", (object?)student.AverageGrade ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@minSubject",   (object?)student.MinSubject ?? DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@maxSubject",   (object?)student.MaxSubject ?? DBNull.Value));

                cmd.ExecuteNonQuery();
                Console.WriteLine("Student record inserted");
            }

            public void UpdateStudent(string fullName, string newGroupName)
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Students SET GroupName = @groupName WHERE FullName = @fullName", connection);

                cmd.Parameters.Add(new SqlParameter("@groupName", newGroupName));
                cmd.Parameters.Add(new SqlParameter("@fullName",  fullName));

                cmd.ExecuteNonQuery();
                Console.WriteLine("Student record updated");
            }

            public void DeleteStudent(string fullName)
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Students WHERE FullName = @fullName", connection);

                cmd.Parameters.Add(new SqlParameter("@fullName", fullName));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student record deleted");
            }

            public void PrintAllStudents()
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader.GetName(i) + "  ");
                Console.WriteLine("\n------------------");

                while (reader.Read())
                {
                    var fullName      = reader["FullName"];
                    var groupName     = reader["GroupName"];
                    var averageGrade  = reader["AverageGrade"];
                    var minSubject    = reader["MinSubject"];
                    var maxSubject    = reader["MaxSubject"];

                    Console.WriteLine($"{fullName}\t{groupName}\t{averageGrade}\t{minSubject}\t{maxSubject}");
                }
                reader.Close();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                ElectronicJournalManager manager = new ElectronicJournalManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n=== Electronic Journal Menu ===");
                    Console.WriteLine("1. Add a new student");
                    Console.WriteLine("2. View all students");
                    Console.WriteLine("3. Update student group");
                    Console.WriteLine("4. Delete student");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");

                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n--- Add New Student ---");
                            Console.Write("Enter Full Name: ");
                            string? fullName = Console.ReadLine();

                            Console.Write("Enter Group: ");
                            string? groupName = Console.ReadLine();

                            Console.Write("Enter Average Grade: ");
                            decimal? averageGrade = decimal.Parse(Console.ReadLine());

                            Console.Write("Enter Subject with Min Grade: ");
                            string? minSubject = Console.ReadLine();

                            Console.Write("Enter Subject with Max Grade: ");
                            string? maxSubject = Console.ReadLine();

                            manager.InsertStudent(new Student()
                            {
                                FullName = fullName,
                                GroupName = groupName,
                                AverageGrade = averageGrade,
                                MinSubject = minSubject,
                                MaxSubject = maxSubject
                            });

                            Console.WriteLine("Student successfully added!");
                            break;

                        case "2":
                            Console.WriteLine("\n--- List of Students ---");
                            manager.PrintAllStudents();
                            break;

                        case "3":
                            Console.WriteLine("\n--- Update Student Group ---");
                            Console.Write("Enter Full Name of the student: ");
                            string? updateName = Console.ReadLine();

                            Console.Write("Enter new Group Name: ");
                            string? newGroupName = Console.ReadLine();

                            manager.UpdateStudent(updateName, newGroupName);
                            break;

                        case "4":
                            Console.WriteLine("\n--- Delete Student ---");
                            Console.Write("Enter Full Name of the student to delete: ");
                            string? deleteName = Console.ReadLine();

                            manager.DeleteStudent(deleteName);
                            break;

                        case "5":
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                manager.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}

