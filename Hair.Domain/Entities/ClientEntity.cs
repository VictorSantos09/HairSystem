using System;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do cliente do salão
    /// </summary>
    public sealed class ClientEntity : BaseEntity
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
        /// <summary>
        /// Prestação de serviço a ser recebido.
        /// </summary>
        public ServiceOrderEntity Duty { get; set; }

        public ClientEntity(string name, string? email, string phoneNumber, Guid userID, ServiceOrderEntity duty)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            UserID = userID;
            Duty = duty;
        }

        public ClientEntity()
        {

        }
    }
}
