using Hair.Domain.Entities;
using Hair.Repository.EntitiesSql;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="ProductEntity"/>.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public void Create(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        private List<ProductEntity> ConvertToEntity(List<SaloonItemEntityFromSql> itensSql)
        {
            var output = new List<ProductEntity>();

            foreach (var item in itensSql)
            {
                var toAdd = new ProductEntity();
                toAdd.Price = item.Price;
                toAdd.QuantityAvaible = item.Quantity_Avaible;
                toAdd.Id = item.Id;
                toAdd.UserID = item.Saloon_Id;

                output.Add(toAdd);
            }

            return output;
        }

        private ProductEntity ConvertToEntity(SaloonItemEntityFromSql itemSql)
        {
            var output = new ProductEntity();
            output.Price = itemSql.Price;
            output.QuantityAvaible = itemSql.Quantity_Avaible;
            output.Id = itemSql.Id;
            output.UserID = itemSql.Saloon_Id;

            return output;
        }
    }
}