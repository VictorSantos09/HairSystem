using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IUpdate<T>
    {
        void Update(T entity);
    }
}