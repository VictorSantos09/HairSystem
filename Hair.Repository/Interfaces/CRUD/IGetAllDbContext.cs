namespace Hair.Repository.Interfaces.CRUD
{

    /// <summary>
    /// Representa a interface que define um método para obter todas as entidades do tipo fornecido.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade a ser retornado pela interface, deve ser fornecido ao implementar a interface.</typeparam>
    public interface IGetAllDbContext<T>
    {
        /// <summary>
        /// Obtém todas as entidades como uma lista de objetos do tipo fornecido.
        /// </summary>
        /// <returns>Uma lista de objetos do tipo fornecido representando todas as entidades.</returns>
        List<T> GetAll();
    }
}