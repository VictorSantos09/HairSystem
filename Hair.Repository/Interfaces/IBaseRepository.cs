using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{

    /// Essa interface define um contrato para um repositório básico, especificando que qualquer classe que o implemente 
    /// deve fornecer métodos para criar, remover, recuperar e atualizar entidades do tipo T com as funções de Add, GetAll,
    /// GetById, Remove e Update.
    public interface IBaseRepository<T> : ICreate<T>, IRemove, IGetAll<T>, IGetById<T>, IUpdate<T>
    {

    }
}