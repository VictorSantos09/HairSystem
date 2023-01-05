namespace Hair.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T? GetById(Guid id);
        public void Remove(Guid id);
        public void Update(Guid id, T newEntity);
    }
}