using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces
{
    public interface IServiceTypeRequestDbContext : IApplicationDbContext<UserServiceTypeEntity>, IGetByNameDbContext<UserServiceTypeEntity>
    {
    }
}
