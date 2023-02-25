namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do endereço
    /// </summary>
    public class AddressEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Complement { get; set; }
        public string FullAddress { get; set; }
        public AddressEntity(string street, string number, string city, string state, string? complement)
        {
            Street = street.ToUpper();
            Number = number.ToUpper();
            City = city.ToUpper();
            State = state.ToUpper();
            Complement = complement == null ? complement : complement.ToUpper();
            FullAddress = $"{Street},{Number}. {City} - {State}. {Complement}";
        }

        public AddressEntity()
        {

        }
    }
}
