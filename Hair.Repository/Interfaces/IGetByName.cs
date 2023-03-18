namespace Hair.Repository.Interfaces
{
    public interface IGetByName<T>
    {
        T GetByName(string name);
    }
}