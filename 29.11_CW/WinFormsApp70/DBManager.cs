using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp70
{
    public class FileFromDB
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Extension { get; set; }
        public byte[]? Data { get; set; }
    }
    public class DBManager : IDisposable
    {
        string connectionData = @"Server=localhost\SQLEXPRESS;
                                  Database=master;
                                  Trusted_Connection=True;
                                  Encrypt=False;
                                  TrustServerCertificate=True";
        SqlConnection connection;

        public DBManager(string? newDatabase) 
        {
            connection = new SqlConnection(connectionData);
            connection.Open();
            connection.ChangeDatabase(newDatabase);
        }

        public void Dispose() { connection.Close(); }

        public DataTable ShowTables() => connection.GetSchema("Tables");

        public SqlDataReader GetAllFromTable(string? tableName)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM {tableName}", connection);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string? query)
        { 
            SqlCommand cmd = new SqlCommand(query, connection);
            return cmd.ExecuteScalar();
        }

        public void SaveFile(string? fileName)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Files Values (@title, @extension, @data)", connection);

            string name = fileName.Substring(fileName.LastIndexOf('\\') + 1);

            string title = name.Substring(0, name.IndexOf("."));
            string extension = name.Substring(name.IndexOf("."));

            cmd.Parameters.Add(new SqlParameter("@title", title));
            cmd.Parameters.Add(new SqlParameter("@extension", extension));

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);

                cmd.Parameters.Add(new SqlParameter("@data", bytes));
            }

            cmd.ExecuteNonQuery();
        }

        public void LoadFiles()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Files", connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    FileFromDB myFile = new FileFromDB();

                    myFile.ID = reader.GetInt32(0);
                    myFile.Title = reader.GetString(1);
                    myFile.Extension = reader.GetString(2);
                    myFile.Data = (byte[])reader.GetValue(3);

                    using (FileStream fs = new FileStream(myFile.Title + myFile.Extension, FileMode.Create))
                    {
                        fs.Write(myFile.Data, 0, myFile.Data.Length);
                        MessageBox.Show($"FILE {myFile.Title + myFile.Extension} LOADED!");
                    }
                }
            }
        }

        //-----------------------------------
        // 27.11.2024
        public string ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                string result = "";
                for (int i = 0; i < reader.FieldCount; i++)
                    result += reader.GetName(i) + "\t";
                result += "\n";

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        result += reader.GetValue(i) + "\t";
                    result += "\n";
                }

                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }
        //-----------------------------------
        
    }
}
