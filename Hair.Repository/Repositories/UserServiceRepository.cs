using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Repository.Repositories
{
    public class UserServiceRepository : IUserServiceRepository
    {
        public void Create(UserServiceEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<UserServiceEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<UserServiceEntity> GetAllByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserServiceEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserServiceEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
