using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="SaloonItemEntity"/>.
    /// </summary>
    public class StorageRepository : IBaseRepository<SaloonItemEntity>
    {
        private readonly static string TableName = "SALOON_ITEMS";

        public void Create(SaloonItemEntity item)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"INSERT INTO {TableName} VALUES (@ID, @NAME, @PRICE, @QUANTITY_AVAILABLE, @SALOON_ID)";

                var cmd = new SqlCommand(query, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@ID", item.Id);
                cmd.Parameters.AddWithValue("@NAME", item.Name);
                cmd.Parameters.AddWithValue("@PRICE", item.Price);
                cmd.Parameters.AddWithValue("@QUANTITY_AVAILABLE", item.QuantityAvaible);
                cmd.Parameters.AddWithValue("@SALOON_ID", item.SaloonId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<SaloonItemEntity> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var itens = new List<SaloonItemEntity>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var item = new SaloonItemEntity();

                    item.Id = reader.GetGuid("ID");
                    item.SaloonId = reader.GetGuid("SALOON_ID");
                    item.Name = reader.GetString("NAME");
                    item.Price = reader.GetDouble("PRICE");
                    item.QuantityAvaible = reader.GetInt32("QUANTITY_AVAILABLE");

                    itens.Add(item);
                }

                return itens;
            }
        }

        public SaloonItemEntity? GetById(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName} WHERE Id= @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                return BuildEntity(cmd.ExecuteReader());
            }
        }

        public bool Remove(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"DELETE FROM {TableName} WHERE ID= @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                return true;
            }
        }

        public void Update(SaloonItemEntity item)
        {

        }

        private SaloonItemEntity? BuildEntity(SqlDataReader reader)
        {
            SaloonItemEntity? item = new SaloonItemEntity();
                while (reader.Read())
                {
                    item.Id = reader.GetGuid("ID");
                    item.SaloonId = reader.GetGuid("SALOON_ID");
                    item.Name = reader.GetString("NAME");
                    item.Price = reader.GetDouble("PRICE");
                    item.QuantityAvaible = reader.GetInt32("QUANTITY_AVAILABLE");
                }

            return item.Id == Guid.Empty ? null : item;
        }

    }
}