using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IUserRepository : IApplicationDbContext<UserEntity>, IGetByEmailDbContext
    {

    }
}