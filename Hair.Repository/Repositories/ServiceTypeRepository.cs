using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRequest
    {
        public void Create(UserServiceTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<UserServiceTypeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserServiceTypeEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserServiceTypeEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserServiceTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
