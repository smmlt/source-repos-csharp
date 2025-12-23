using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._11_CW
{
    public class DBManager
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

        public void ShowTables()
        {
            var tables = connection.GetSchema("Tables");
        }
    }
}
