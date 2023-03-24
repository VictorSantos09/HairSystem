namespace Hair.Repository.Interfaces
{
    public interface IGetByNameDbContext<T>
    {
        T GetByName(string name);
    }
}