namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Representa a interface que implementa as interfaces ICreate<T> e IUpdate<T>.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade que será manipulada.</typeparam>
    public interface ICreateUpdate<T> : ICreate<T>, IUpdate<T>
    {
    }
}