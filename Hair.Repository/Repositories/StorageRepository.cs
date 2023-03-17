using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.EntitiesSql;
using Hair.Repository.Interfaces;
using System.Data;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="ItemEntity"/>.
    /// </summary>
    public class StorageRepository : IBaseRepository<ItemEntity>
    {
        public void Create(ItemEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateItem @ID, @NAME, @PRICE, @QUANTITY_AVAILABLE, @SALOON_ID", new
                {
                    ID = entity.Id,
                    NAME = entity.Name,
                    PRICE = entity.Price,
                    QUANTITY_AVAILABLE = entity.QuantityAvaible,
                    SALOON_ID = entity.UserID
                });
            }
        }

        public List<ItemEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return ConvertToEntity(conn.Query<SaloonItemEntityFromSql>("dbo.spGetAllItens").ToList());
            }
        }

        public ItemEntity? GetById(Guid id)
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

        public void Update(ItemEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateItem @ID, @NAME, @PRICE, @QUANTITY_AVAILABLE, @SALOON_ID", new
                {
                    ID = entity.Id,
                    NAME = entity.Name,
                    PRICE = entity.Price,
                    QUANTITY_AVAILABLE = entity.QuantityAvaible,
                    SALOON_ID = entity.UserID
                });
            }
        }

        private List<ItemEntity> ConvertToEntity(List<SaloonItemEntityFromSql> itensSql)
        {
            var output = new List<ItemEntity>();

            foreach (var item in itensSql)
            {
                var toAdd = new ItemEntity();
                toAdd.Name = item.Name;
                toAdd.Price = item.Price;
                toAdd.QuantityAvaible = item.Quantity_Avaible;
                toAdd.Id = item.Id;
                toAdd.UserID = item.Saloon_Id;

                output.Add(toAdd);
            }

            return output;
        }

        private ItemEntity ConvertToEntity(SaloonItemEntityFromSql itemSql)
        {
            var output = new ItemEntity();
            output.Name = itemSql.Name;
            output.Price = itemSql.Price;
            output.QuantityAvaible = itemSql.Quantity_Avaible;
            output.Id = itemSql.Id;
            output.UserID = itemSql.Saloon_Id;

            return output;
        }
    }
}