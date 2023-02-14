using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="SaloonItemEntity"/>.
    /// </summary>
    public class StorageRepository : BaseRepository<SaloonItemEntity>, ICreateUpdate<SaloonItemEntity>, IBaseRepository<SaloonItemEntity>
    {
        private readonly static string TableName = "SALOON_ITEMS";
        public StorageRepository() : base(TableName)
        {

        }

        public void Create(SaloonItemEntity entity)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand ($"INSERT INTO {TableName} VALUES (@ID, @NAME, @PRICE, @QUANTITY_AVAILABLE)");

                conn.Open();    

                query.Parameters.AddWithValue("@ID", entity.Id);
                query.Parameters.AddWithValue("@NAME", entity.Name);
                query.Parameters.AddWithValue("@PRICE", entity.Price);  
                query.Parameters.AddWithValue("@QUANTITY_AVAILABLE", entity.QuantityAvaible);
     
                query.ExecuteNonQueryAsync();
            }
        }

        public void Update(SaloonItemEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute($"UPDATE {TableName} SET NAME = {entity.Name}, PRICE = {entity.Price}, QUANTITY_AVAILABLE = {entity.QuantityAvaible} WHERE ID = {entity.Id}");
            }
        }
    }
}