using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IFunctionTypeRequest : IBaseRepository<FunctionTypeEntity>, IGetByName<FunctionTypeEntity>
    {
    }
}