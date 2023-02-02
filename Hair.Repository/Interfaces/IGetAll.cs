using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para recuperar todas as entidades do repositório. 
    /// Qualquer classe que a implemente deve fornecer um método GetAll que retorna uma coleção de entidades do tipo T.
    
    public interface IGetAll<T>
    {
        public IEnumerable<T> GetAll();    
    }
}