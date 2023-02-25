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
            throw new NotImplementedException();
        }

        public SaloonItemEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SaloonItemEntity item)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"UPDATE {TableName} SET NAME = @Name, PRICE = @Price, QUANTITY_AVAILABLE = @QuantityAvailable, SALOON_ID= @Saloon_Id WHERE ID = @Id");

                conn.Open();

                cmd.Parameters.AddWithValue("@NAME", item.Name);
                cmd.Parameters.AddWithValue("@PRICE", item.Price);
                cmd.Parameters.AddWithValue("@QUANTITY_AVAILABLE", item.QuantityAvaible);
                cmd.Parameters.AddWithValue("@ID", item.Id);
                cmd.Parameters.AddWithValue("@SALOON_ID", item.SaloonId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}