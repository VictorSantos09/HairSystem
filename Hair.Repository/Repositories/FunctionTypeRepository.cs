using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    public sealed class FunctionTypeRepository : IFunctionTypeRequest
    {
        public void Create(FunctionTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<FunctionTypeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public FunctionTypeEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public FunctionTypeEntity? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(FunctionTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
