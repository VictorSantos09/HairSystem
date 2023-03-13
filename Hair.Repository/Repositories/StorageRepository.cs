using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.EntitiesSql;
using Hair.Repository.Interfaces;
using System.Data;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="SaloonItemEntity"/>.
    /// </summary>
    public class StorageRepository : IBaseRepository<SaloonItemEntity>
    {
        public void Create(SaloonItemEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateItem @ID, @NAME, @PRICE, @QUANTITY_AVAILABLE, @SALOON_ID", new
                {
                    ID = entity.Id,
                    NAME = entity.Name,
                    PRICE = entity.Price,
                    QUANTITY_AVAILABLE = entity.QuantityAvaible,
                    SALOON_ID = entity.SaloonId
                });
            }
        }

        public List<SaloonItemEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return ConvertToEntity(conn.Query<SaloonItemEntityFromSql>("dbo.spGetAllItens").ToList());
            }
        }

        public SaloonItemEntity? GetById(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return ConvertToEntity(conn.Query<SaloonItemEntityFromSql>("dbo.spGetItemById @ID", new { ID = id }).FirstOrDefault());
            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spDeleteItem @ID", new { ID = id });
            }

            return true;
        }

        public void Update(SaloonItemEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateItem @ID, @NAME, @PRICE, @QUANTITY_AVAILABLE, @SALOON_ID", new
                {
                    ID = entity.Id,
                    NAME = entity.Name,
                    PRICE = entity.Price,
                    QUANTITY_AVAILABLE = entity.QuantityAvaible,
                    SALOON_ID = entity.SaloonId
                });
            }
        }

        private List<SaloonItemEntity> ConvertToEntity(List<SaloonItemEntityFromSql> itensSql)
        {
            var output = new List<SaloonItemEntity>();

            foreach (var item in itensSql)
            {
                var toAdd = new SaloonItemEntity();
                toAdd.Name = item.Name;
                toAdd.Price = item.Price;
                toAdd.QuantityAvaible = item.Quantity_Avaible;
                toAdd.Id = item.Id;
                toAdd.SaloonId = item.Saloon_Id;

                output.Add(toAdd);
            }

            return output;
        }

        private SaloonItemEntity ConvertToEntity(SaloonItemEntityFromSql itemSql)
        {
            var output = new SaloonItemEntity();
            output.Name = itemSql.Name;
            output.Price = itemSql.Price;
            output.QuantityAvaible = itemSql.Quantity_Avaible;
            output.Id = itemSql.Id;
            output.SaloonId = itemSql.Saloon_Id;

            return output;
        }
    }
}