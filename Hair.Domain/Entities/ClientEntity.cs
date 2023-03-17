using System;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do cliente do salão
    /// </summary>
    public class ClientEntity : BaseEntity
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 
        /// Nome do cliente.
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// Email do cliente.
        /// 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 
        /// Telefone do cliente.
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        public ClientEntity(string name, string? email, string phoneNumber, Guid userID)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            Email = email.ToUpper();
            PhoneNumber = phoneNumber;
            UserID = userID;
        }

        public ClientEntity()
        {

        }
    }
}
