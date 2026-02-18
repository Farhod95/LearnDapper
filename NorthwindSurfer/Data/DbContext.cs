using Microsoft.Data.SqlClient;
using System.Data;

namespace NorthwindSurfer.Data
{
    public class DbContext
    {

        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;TrustServerCertificate=True;";

        public IDbConnection connection => new SqlConnection(connectionString);

    }
}
