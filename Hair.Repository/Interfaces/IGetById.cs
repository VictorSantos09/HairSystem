using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Representa a interface IGetById<T>, que fornece um método para recuperar uma entidade com um id especificado/// Representa a interface IGetById<T>, que fornece um método para recuperar uma entidade com um id especificado.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade a ser retornado da interface, deve ser derivado de <cref="BaseEntity"/>.</typeparam>
    public interface IGetById<T>
    {
        /// <summary>
        /// Recupera a entidade com o id especificado a partir da fonte de dados como um objeto do tipo T.
        /// </summary>
        /// <param name="id">O id da entidade a ser recuperada.</param>
        /// <returns>Um objeto do tipo T representando a entidade com o id especificado, ou nulo se tal entidade não existir.</returns>
        T? GetById(Guid id);
    }
}