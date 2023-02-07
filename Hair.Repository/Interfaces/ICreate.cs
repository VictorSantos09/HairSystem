namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Representa a interface que permite a criação de uma entidade no banco de dados.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade a ser criada.</typeparam>
    public interface ICreate<T>
    {
        /// <summary>
        /// Cria uma entidade no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser criada.</param>
        void Create(T entity);
    }
}