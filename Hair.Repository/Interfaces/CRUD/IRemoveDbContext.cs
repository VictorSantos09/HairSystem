namespace Hair.Repository.Interfaces.CRUD
{
    /// <summary>
    /// Representa a interface que define um método para remover uma entidade pelo seu Id.
    /// </summary>
    public interface IRemoveDbContext
    {
        /// <summary>
        /// Remove a entidade com o Id especificado.
        /// </summary>
        /// <param name="id">O Id da entidade a ser removida.</param>
        bool Remove(Guid id);
    }
}