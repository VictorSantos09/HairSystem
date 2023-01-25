using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using Dapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso dos itens do salão
    /// <para>Como quantidades de navalhas, maquinas entre outros da entidade <see cref="SaloonItemEntity"/></para>
    /// </summary>
    public class StorageRepository : BaseRepository<SaloonItemEntity>
    {
        public StorageRepository() : base("StorageItens")
        {
        }

        public void Create(SaloonItemEntity item)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"INSERT INTO SALOON_ITEMS (ID, NAME, PRICE, QUANTITY_AVAILABLE) 
                  VALUES (@Id, @Name, @Price, @QuantityAvaible)";
                var affectedRows = connection.Execute(query, new
                {
                    Id = Guid.NewGuid(),
                    item.Name,
                    item.Price,
                    item.QuantityAvaible
                });
            }
        }

        public void Read(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "SELECT * FROM SALOON_ITEMS WHERE ID = @Id";
                var item = connection.QueryFirstOrDefault<SaloonItemEntity>(query, new { id });
            }
        }

        public void Update(SaloonItemEntity item)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"UPDATE SALOON_ITEMS SET NAME = @Name, PRICE = @Price, QUANTITY_AVAILABLE = @QuantityAvaible
                  WHERE ID = @Id";
                var affectedRows = connection.Execute(query, new
                {
                    item.Name,
                    item.Price,
                    item.QuantityAvaible,
                    item.Id
                });
            }
        }
        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "DELETE FROM SALOON_ITEMS WHERE ID = @Id";
                var affectedRows = connection.Execute(query, new { id });
            }
        }
    }
}
