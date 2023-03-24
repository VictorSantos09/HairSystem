namespace Hair.Repository.Interfaces.CRUD
{
    public interface IGetByNameDbContext<T>
    {
        T GetByName(string name);
    }
}