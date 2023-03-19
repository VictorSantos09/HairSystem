using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRequest
    {
        public void Create(TaskTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TaskTypeEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskTypeEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public TaskTypeEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
