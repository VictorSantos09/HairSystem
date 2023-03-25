using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IServiceOrderRepository : IApplicationDbContext<ServiceOrderEntity>, IGetAllByUserIdDbContext<ServiceOrderEntity>
    {
    }
}
