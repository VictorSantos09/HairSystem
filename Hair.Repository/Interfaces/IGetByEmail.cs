using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IGetByEmail
    {
        UserEntity GetByEmail(string email, string password);
    }
}
