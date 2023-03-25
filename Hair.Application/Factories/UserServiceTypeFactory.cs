using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class UserServiceTypeFactory
    {
        public UserServiceTypeEntity Create() => new UserServiceTypeEntity();

        public UserServiceTypeEntity Create(string name, int code)
        {
            return new UserServiceTypeEntity(name, code);
        }
    }
}
