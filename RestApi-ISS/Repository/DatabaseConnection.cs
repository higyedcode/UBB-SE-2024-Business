using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Microsoft.Data.SqlClient;

namespace Iss.Repository
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public static string ConnectionString = "Data Source = DESKTOP-56RUGQC\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;";

        // public static string ConnectionString = "Data Source = OMG\\MSSQLSERVER01; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;";
        public SqlConnection SqlConnection { get; private set; } = new SqlConnection(ConnectionString);

        public virtual void OpenConnection()
        {
            if (SqlConnection.State == ConnectionState.Closed)
            {
                SqlConnection.Open();
            }
        }

        public virtual void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
    }
}
