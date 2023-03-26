using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IUserServiceRepository : IApplicationDbContext<UserServiceEntity>, IGetAllByUserIdDbContext<UserServiceEntity>, IGetByNameDbContext<UserServiceEntity>
    {
    }
}
