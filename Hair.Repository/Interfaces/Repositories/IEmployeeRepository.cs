using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IEmployeeRepository : IApplicationDbContext<EmployeeEntity>, IGetByNameDbContext<EmployeeEntity>, IGetAllByUserIdDbContext<EmployeeEntity>
    {
    }
}