using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IServiceTypeRequestDbContext : IApplicationDbContext<UserServiceTypeEntity>, IGetByNameDbContext<UserServiceTypeEntity>
    {
    }
}
