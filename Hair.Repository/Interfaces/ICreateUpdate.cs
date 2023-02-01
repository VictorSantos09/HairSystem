namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface que representa a alteração e criação de entidades de forma singular
    /// através da herança das interfaces ICreate e IUpdate 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreateUpdate<T> : ICreate<T>, IUpdate<T>
    {
    }
}