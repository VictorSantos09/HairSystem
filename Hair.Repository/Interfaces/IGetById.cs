using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IGetById <T>
    {
        public T? GetById(Guid id);
    }
}