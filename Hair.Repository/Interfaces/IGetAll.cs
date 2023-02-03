using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para recuperar todas as entidades do repositório. 
    /// Qualquer classe que a implemente deve fornecer um método GetAll que retorna uma coleção de entidades do tipo T.

    /// <summary>
    /// Representa a interface IGetAll, que define um método para obter todas as entidades do tipo T.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade a ser retornado pela interface, deve ser fornecido ao implementar a interface.</typeparam>
    public interface IGetAll<T>
    {
        /// <summary>
        /// Obtém todas as entidades como uma lista de objetos do tipo T.
        /// </summary>
        /// <returns>Uma lista de objetos do tipo T representando todas as entidades.</returns>
        IEnumerable<T> GetAll();
    }
}