using Hair.Domain.Common;
using Hair.Domain.Database;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Hair.Domain.Entities
{
    public class SaloonItemEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int QuantityAvaible { get; set; }

        public SaloonItemEntity(string name, double price, int quantityAvaible)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }

        public SaloonItemEntity()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NAME, PRICE, QUANTITY_AVAILABLE WHERE ID = {Id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetGuid(0);
                        Name = reader.GetString(1);
                        Price = reader.GetDouble(2);
                        QuantityAvaible = reader.GetInt32(3);
       
                    }
                }
            }
        }

        public void Create()
        {
            using var conn = new SqlConnection(DbInfo.DBConnection);
            var cmd = new SqlCommand($"INSERT INTO SALOON_ITEMS (ID, NAME, PRICE, QUANTITY_AVAILABLE) VALUES ('{Id}', '{Name}', '{Price}', '{QuantityAvaible}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var querry = $"UPDATE SALOON_ITEMS SET NAME = '{Name}', PRICE = {Price}, QUANTITY_AVAILABLE = {QuantityAvaible}') WHERE ID = {Id}";
                var cmd = new SqlCommand(querry, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void Delete()
        {
            using (var conn = new SqlConnection(DbInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM USERS WHERE ID = {Id}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}