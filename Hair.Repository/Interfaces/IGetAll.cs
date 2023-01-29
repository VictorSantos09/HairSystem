using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IGetAll<T>
    {
        public IEnumerable<T> GetAll();    
    }
}