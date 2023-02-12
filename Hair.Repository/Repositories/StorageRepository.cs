using Dapper;
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
    public class StorageRepository : BaseRepository<SaloonItemEntity>, ICreateUpdate<SaloonItemEntity>, IBaseRepository<SaloonItemEntity>
    {
        private readonly static string TableName = "SALOON_ITEMS";
        public StorageRepository() : base(TableName)
        {

        }

        public void Create(SaloonItemEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute($"INSERT INTO {TableName}", entity);

            }
        }

        public void Update(SaloonItemEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute($"UPDATE {TableName} WHERE ID = {entity.Id}", entity);
            }
        }
    }
}