using Microsoft.Data.SqlClient;

namespace _22._11_CW
{
    class VegetableAndFruit
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public int? Calories { get; set; }
    }

    class VegetablesAndFruitsManager : IDisposable
    {
        string connectionData = @"Server=localhost\SQLEXPRESS;
                              Database=Vegetables_And_Fruits;
                              Trusted_Connection=True;
                              Encrypt=False;
                              TrustServerCertificate=True";
        SqlConnection connection;

        public VegetablesAndFruitsManager()
        {
            connection = new SqlConnection(connectionData);
            connection.Open();
            Console.WriteLine("Connected to Vegetables_And_Fruits database");
        }

        public void Dispose()
        {
            connection.Close();
            Console.WriteLine("Connection closed");
        }

        public void InsertMy(VegetableAndFruit vf)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Info VALUES (@name, @type, @color, @calories)",
                connection);

            cmd.Parameters.Add(new SqlParameter("@name", vf.Name));
            cmd.Parameters.Add(new SqlParameter("@type", (object?)vf.Type ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@color", (object?)vf.Color ?? DBNull.Value));
            cmd.Parameters.Add(new SqlParameter("@calories", (object?)vf.Calories ?? DBNull.Value));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Value inserted");
        }

        public void UpdateMy(string name, string newColor)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Info SET Color = @color WHERE Name = @name", connection);

            cmd.Parameters.Add(new SqlParameter("@color", newColor));
            cmd.Parameters.Add(new SqlParameter("@name", name));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Record updated");
        }

        public void DeleteMy(string name)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Info WHERE Name = @name", connection);

            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Record deleted");
        }

        public void PrintAllInfo()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Info", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader.GetName(i) + "  ");
            Console.WriteLine("\n------------------");

            while (reader.Read())
            {
                var name = reader["Name"];
                var type = reader["Type"];
                var color = reader["Color"];
                var calories = reader["Colorfulness"];

                Console.WriteLine($"{name}\t{type}\t{color}\t{calories}");
            }
            reader.Close();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VegetablesAndFruitsManager manager = new VegetablesAndFruitsManager();

                manager.InsertMy(new VegetableAndFruit()
                {
                    Name = "Cucumber",
                    Type = "Vegetable",
                    Color = "Green",
                    Calories = 20
                });

                manager.UpdateMy("Cucumber", "Dark Green");
                manager.DeleteMy("Cucumber");
                manager.PrintAllInfo();

                manager.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }

}
