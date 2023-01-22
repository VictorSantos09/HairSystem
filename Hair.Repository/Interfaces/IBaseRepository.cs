using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Contrato básico necessario para todos os repositorios, com as funções de Add, GetAll, GetById, Remove e Update
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T? GetById(Guid id);
        public void Remove(Guid id);
        public void Update(Guid id, T newEntity);
    }
}