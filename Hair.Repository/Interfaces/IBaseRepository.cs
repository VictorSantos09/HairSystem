using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Contrato básico necessario para todos os repositorios, com as funções de Add, GetAll, GetById, Remove e Update
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> : ICreate<T>, IRemove, IGetAll<T>, IGetById<T>, IUpdate<T>
    {

    }
}