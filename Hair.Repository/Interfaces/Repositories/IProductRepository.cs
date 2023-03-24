using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IProductRepository : IApplicationDbContext<ProductEntity>, IGetByNameDbContext<ProductEntity>
    {
    }
}
