using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface responsável pela alteração de dados de uma entidade.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdate<T>
    {
        void Update(T entity);
    }
}