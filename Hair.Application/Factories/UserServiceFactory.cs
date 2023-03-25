using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class UserServiceFactory
    {
        public UserServiceEntity Create() => new UserServiceEntity();
        public UserServiceEntity Create(Guid userID, string name, float value, string? description, UserServiceTypeEntity type)
        {
            return new UserServiceEntity(userID, name, value, description, type);
        }
    }
}
