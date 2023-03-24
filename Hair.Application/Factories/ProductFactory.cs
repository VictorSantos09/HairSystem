using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class ProductFactory
    {
        public ProductEntity Create() => new ProductEntity();
        public ProductEntity Create(Guid userID, ProductTypeEntity type, string? description, double price, int quantityAvaible)
        {
            return new ProductEntity(userID, type, description, price, quantityAvaible);
        }
    }
}