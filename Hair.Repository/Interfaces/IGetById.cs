using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface que estabelece a seleção de uma entidade específica pelo Id.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetById <T>
    {
        public T? GetById(Guid id);
    }
}