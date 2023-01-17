using Hair.Domain.Database;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace Hair.Domain.Entities
{
    public class HaircutePriceEntity : BaseEntity
    {
        public double Hair { get; set; }
        public double? Beard { get; set; }
        public double? Mustache { get; set; }
        public HaircutePriceEntity(double hair, double? beard, double? mustache)
        {
            Id = Guid.NewGuid();
            Hair = hair;
            Beard = beard;
            Mustache = mustache;
        }


        public HaircutePriceEntity()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, HAIR, BEARD, MUSTACHE WHERE ID = {Id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetGuid(0);
                        Hair = reader.GetDouble(1);
                        Beard = reader.GetDouble(2);    
                        Mustache = reader.GetDouble(3);

                    }
                }
            }
        }

        public void Create()
        {
            using var conn = new SqlConnection(DbInfo.DBConnection);
            var cmd = new SqlCommand($"INSERT INTO HAIRCUT_PRICES (ID, HAIR, BEARD, MUSTACHE) VALUES ('80', '30', '{Beard}', '{Mustache}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        //public void Create()
        //{
        //    using var conn = new SqlConnection(DbInfo.DBConnection);
        //    var cmd = new SqlCommand($"INSERT INTO HAIRCUT_PRICES (ID, HAIR, BEARD, MUSTACHE) VALUES ('{Id}', '{Hair}', '{Beard}', '{Mustache}')", conn);
        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //}

        public void Update()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var querry = $"UPDATE HAIRCUT_PRICES SET HAIR = '{Hair}', Beard = {Beard}, MUSTACHE = {Mustache}') WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void Delete()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM HAIRCUT_PRICES WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
