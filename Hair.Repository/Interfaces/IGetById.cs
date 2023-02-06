using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Representa a interface que fornece um método para recuperar uma entidade com um id especificado.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade que foi fornecida.</typeparam>
    public interface IGetById<T>
    {
        /// <summary>
        /// Recupera a entidade com o id especificado a partir da fonte de dados como um objeto do tipo T.
        /// </summary>
        /// <param name="id">O id da entidade a ser recuperada.</param>
        /// <returns>Retorna a entidade T com o Id fornecido ou nulo se não existir.</returns>
        T? GetById(Guid id);
    }
}