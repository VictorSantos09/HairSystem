using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class ClientEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ClientEntity(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
