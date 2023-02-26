using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do cliente do salão
    /// </summary>
    public class ClientEntity : IClient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }

        public ClientEntity(string name, string? email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            Email = email.ToUpper();
            PhoneNumber = phoneNumber;
        }

        public ClientEntity()
        {

        }
    }
}
