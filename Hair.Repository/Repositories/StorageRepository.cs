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
                var query = $"INSERT INTO SALOON_ITEMS ID = {entity.Id}, NAME = {entity.Name}, " +
                    $"PRICE = {entity.Price}, QUANTITY_AVAILABLE = {entity.QuantityAvaible}";

                conn.Execute(query);
            }
        }

        public void Update(SaloonItemEntity entity)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE SALOON_ITEMS SET NAME = {entity.Name}, PRICE = {entity.Price}, " +
                    $"QUANTITY_AVAILABLE = {entity.QuantityAvaible} WHERE ID = {entity.Id}";

                conn.Execute(query);
            }
        }
    }
}