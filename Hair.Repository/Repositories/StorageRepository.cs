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
            throw new NotImplementedException();
        }

        public List<ItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ItemEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemEntity entity)
        {
            throw new NotImplementedException();
        }

        private List<ItemEntity> ConvertToEntity(List<SaloonItemEntityFromSql> itensSql)
        {
            var output = new List<ItemEntity>();

            foreach (var item in itensSql)
            {
                var toAdd = new ItemEntity();
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
            output.Price = itemSql.Price;
            output.QuantityAvaible = itemSql.Quantity_Avaible;
            output.Id = itemSql.Id;
            output.UserID = itemSql.Saloon_Id;

            return output;
        }
    }
}