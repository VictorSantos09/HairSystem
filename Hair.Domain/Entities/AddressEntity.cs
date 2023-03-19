using System;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do endereço
    /// </summary>
    public sealed class AddressEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Rua.
        /// 
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 
        /// Número do estabelecimento.
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// Cidade.
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// Estado.
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// Complemento do endereço.
        /// 
        /// </summary>
        public string? Complement { get; set; }
        /// <summary>
        /// 
        /// Endereço completo.
        /// 
        /// </summary>
        public string FullAddress { get; set; }
        /// <summary>
        /// 
        /// CEP.
        /// 
        /// </summary>
        public string CEP { get; set; }
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid UserID { get; set; }

        public AddressEntity(string street, string number, string city, string state, string? complement, string cep, Guid userId)
        {
            Id = Guid.NewGuid();
            Street = street;
            Number = number;
            City = city;
            State = state;
            Complement = complement;
            CEP = cep;
            UserID = userId;
        }

        public AddressEntity()
        {

        }
    }
}
