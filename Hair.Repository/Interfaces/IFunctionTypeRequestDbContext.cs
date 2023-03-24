using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces
{
    public interface IFunctionTypeRequestDbContext : IApplicationDbContext<FunctionTypeEntity>, IGetByNameDbContext<FunctionTypeEntity>
    {
    }
}