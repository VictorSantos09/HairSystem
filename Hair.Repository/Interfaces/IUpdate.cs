using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    ///Essa interface define um contrato para atualizar uma entidade no repositório. 
    ///Qualquer classe que o implemente deve fornecer um método Update que recebe uma
    ///entidade do tipo T como parâmetro e atualiza a entidade correspondente no repositório.
    public interface IUpdate<T>
    {
        void Update(T entity);
    }
}