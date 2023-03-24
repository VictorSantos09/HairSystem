namespace Hair.Repository.Interfaces.CRUD
{
    /// <summary>
    /// Representa a interface que define um método para atualizar uma entidade do tipo fornecido.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade a ser atualizada.</typeparam>
    public interface IUpdateDbContext<T>
    {
        /// <summary>
        /// Atualiza a entidade especificada.
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada.</param>
        void Update(T entity);
    }
}