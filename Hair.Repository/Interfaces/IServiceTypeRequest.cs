using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IServiceTypeRequest : IBaseRepository<UserServiceTypeEntity>, IGetByName<UserServiceTypeEntity>
    {
    }
}
