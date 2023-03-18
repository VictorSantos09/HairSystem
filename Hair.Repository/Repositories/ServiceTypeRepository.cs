using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRequest
    {
        public void Create(ServiceTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<ServiceTypeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceTypeEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceTypeEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
