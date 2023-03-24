namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do endereço
    /// </summary>
    public sealed class AddressEntity : BaseEntity
    {
        /// <summary>
        /// Rua.
        /// </summary>
        public StreetEntity Street { get; set; }
        /// <summary>
        /// Cidade.
        /// </summary>
        public CityEntity City { get; set; }
        /// <summary>
        /// Estado.
        /// </summary>
        public StateEntity State { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        public CountryEntity Country { get; set; }
        /// <summary>
        /// Complemento do endereço.
        /// </summary>
        public string? Complement { get; set; }
        /// <summary>
        /// Endereço completo.
        /// </summary>
        public string FullAddress { get; set; }
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid UserID { get; set; }

        public AddressEntity(StreetEntity street, CityEntity city, StateEntity state, CountryEntity country, string? complement, Guid userID, string fullAddress)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            Complement = complement;
            UserID = userID;
            FullAddress = fullAddress;
        }

        public AddressEntity()
        {

        }
    }
}
