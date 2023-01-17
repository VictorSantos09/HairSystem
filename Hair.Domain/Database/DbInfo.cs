using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hair.Domain.Entities;

namespace Hair.Domain.Database
{
    public class DbInfo
    {
        public const string DBConnection = @"Data Source=DESKTOP-3MAQE1O\\SQLEXPRESS; Initial catalog=HairSystem_DB; User=sa; Password=sa; Trusted_Connection=True;";

        public static void DatabaseTest()
        {
            using (var conn = new SqlConnection(DBConnection))
            {
                var cmd = new SqlCommand("SELECT * FROM USERS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
