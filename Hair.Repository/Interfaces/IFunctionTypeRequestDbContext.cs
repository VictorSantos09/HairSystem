using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IFunctionTypeRequestDbContext : IApplicationDbContext<FunctionTypeEntity>, IGetByNameDbContext<FunctionTypeEntity>
    {
    }
}