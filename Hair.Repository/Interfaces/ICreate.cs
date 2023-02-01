namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Interface que representa a função de adicionar/criar entidades que fazem parte do contrato estabelecido
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreate<T>
    {
        void Create(T entity);
    }
}