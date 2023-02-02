namespace Hair.Repository.Interfaces
{
    /// Essa interface define um contrato para a criação de entidades. Qualquer classe que o implemente deve
    /// fornecer um método Create que recebe uma entidade do tipo T como parâmetro e cria uma nova instância 
    /// dessa entidade no repositório.
    
    public interface ICreate<T>
    {
        void Create(T entity);
    }
}