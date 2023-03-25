namespace Hair.Repository.Interfaces.Security
{
    public interface IKeyManagment
    {
        byte[] Create(string text);
        byte[] Get(string name);
    }
}