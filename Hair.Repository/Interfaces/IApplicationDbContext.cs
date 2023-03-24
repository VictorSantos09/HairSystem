namespace Hair.Repository.Interfaces
{

    /// <summary>
    /// Representa a interface que implementa as interfaces ICreate<T>, IRemove, IGetAll<T>, IGetById<T> e IUpdate<T>.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade a ser retornado pelo repositório, deve ser derivado de alguma classe.</typeparam>
    public interface IApplicationDbContext<T> : ICreateDbContext<T>, IRemoveDbContext, IGetAllDbContext<T>, IGetByIdDbContext<T>, IUpdateDbContext<T>, IGetByNameDbContext<T>
    {
    }
}