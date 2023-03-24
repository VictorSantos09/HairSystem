using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class ServiceOrderFactory
    {
        public ServiceOrderEntity Create() => new ServiceOrderEntity();
        public ServiceOrderEntity Create(Guid userID, DateTime date, ClientEntity client, UserServiceTypeEntity service)
        {
            return new ServiceOrderEntity(userID, date, client, service);
        }
    }
}