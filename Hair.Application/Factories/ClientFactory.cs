using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class ClientFactory
    {
        public ClientEntity Create() => new ClientEntity();
        public ClientEntity Create(string name, string? email, string phoneNumber, Guid userID, ServiceOrderEntity order)
        {
            return new ClientEntity(name, email, phoneNumber, userID, order);
        }
    }
}