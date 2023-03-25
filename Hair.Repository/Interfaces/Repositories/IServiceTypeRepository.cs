using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IServiceTypeRepository : IApplicationDbContext<UserServiceTypeEntity>, IGetByNameDbContext<UserServiceTypeEntity>, 
        IGetAllByUserIdDbContext<UserServiceTypeEntity>
    {
    }
}