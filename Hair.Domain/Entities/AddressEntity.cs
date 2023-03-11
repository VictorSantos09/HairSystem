namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do endereço
    /// </summary>
    public class AddressEntity
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
        /// 
        /// Representa a relação entre o endereço e a entidade correspondente.
        /// 
        /// </summary>
        public Guid OwnerId { get; set; }

        public AddressEntity(string street, string number, string city, string state, string? complement, string cep, Guid ownerId)
        {
            Street = street.ToUpper();
            Number = number.ToUpper();
            City = city.ToUpper();
            State = state.ToUpper();
            Complement = string.IsNullOrWhiteSpace(complement) == true || string.IsNullOrEmpty(complement) == true ? null : complement.ToUpper();
            FullAddress = $"{Street},{Number}. {City} - {State}. {Complement}";
            CEP = cep;
            OwnerId = ownerId;
        }

        public AddressEntity()
        {

        }
    }
}
