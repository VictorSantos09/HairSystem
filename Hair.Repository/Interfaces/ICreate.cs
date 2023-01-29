namespace Hair.Repository.Interfaces
{
    public interface ICreate<T>
    {
        void Create(T entity);
    }
}