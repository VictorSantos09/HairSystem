using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class ProductTypeFactory
    {
        public ProductTypeEntity Create() => new ProductTypeEntity();
        public ProductTypeEntity Create(string name, int code)
        {
            return new ProductTypeEntity(name, code);
        }
    }
}
