using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface de seleção genérica de dados de uma entidade.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetAll<T>
    {
        public IEnumerable<T> GetAll();    
    }
}