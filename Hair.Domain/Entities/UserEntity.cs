namespace Hair.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string SaloonName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string Password { get; set; }
        public AddressEntity Adress { get; set; }
        public HaircutePriceEntity Prices { get; set; }
        public List<HaircuteEntity> Haircutes { get; set; } = new();
        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string password, AddressEntity address, string? cNPJ, HaircutePriceEntity priceEntity)
        {
            Id = Guid.NewGuid();
            SaloonName = saloonName;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Adress = address;
            CNPJ = cNPJ;
            Prices = priceEntity;
        }
        public UserEntity()
        {

        }
    }
}