using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using Dapper;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso dos itens do salão
    /// <para>Como quantidades de navalhas, maquinas entre outros da entidade <see cref="SaloonItemEntity"/></para>
    /// </summary>
    public class StorageRepository : BaseRepository<SaloonItemEntity>, ICreateUpdate<SaloonItemEntity>
    {
        public StorageRepository() : base("SALOON_ITEMS")
        {

        }

        public void Create(SaloonItemEntity entity)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO SALOON_ITEMS (ID, NAME, PRICE, QUANTITY_AVAILABLE) VALUES ('{entity.Id}', '{entity.Name}', '{entity.Price}', '{entity.QuantityAvaible}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }

        public void Update(SaloonItemEntity entity)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE SALOON_ITEMS SET NAME = {entity.Name}, PRICE = {entity.Price}, " +
                    $"QUANTITY_AVAILABLE = {entity.QuantityAvaible} WHERE ID = {entity.Id}");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}