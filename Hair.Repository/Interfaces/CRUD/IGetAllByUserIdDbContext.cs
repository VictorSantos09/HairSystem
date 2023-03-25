namespace Hair.Repository.Interfaces.CRUD
{
    public interface IGetAllByUserIdDbContext<T>
    {
        List<T> GetAllByUserId(Guid userId);
    }
}
