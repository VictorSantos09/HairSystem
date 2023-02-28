namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do cliente do salão
    /// </summary>
    public class ClientEntity : BaseEntity
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Email do cliente
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Telefone do cliente
        /// </summary>
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
