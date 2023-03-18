using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.DataBase
{
    internal class ConnectionFactory
    {
        private static string DBConnection = "Server=;Database=HairSystem_DB; User=; Password=; Trusted_Connection=True;";

        public static IDbConnection BaseConnection()
        {

            return new SqlConnection(DBConnection);
        }
    }
}
