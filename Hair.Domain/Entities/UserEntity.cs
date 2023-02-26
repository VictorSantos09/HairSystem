namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do usuário
    /// </summary>
    public class UserEntity : BaseEntity
    {
        public string SaloonName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string Password { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string? GoogleMapsSource { get; set; }
        public AddressEntity Address { get; set; } = new AddressEntity();
        public HaircutPriceEntity Prices { get; set; } = new HaircutPriceEntity();
        public List<HaircutEntity> Haircuts { get; set; } = new();
        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string password,
            AddressEntity address, string? cNPJ, HaircutPriceEntity priceEntity, DateTime openTime, string? googleMapsSource, DateTime closeTime)
        {
            Id = Guid.NewGuid();
            SaloonName = saloonName.ToUpper();
            OwnerName = ownerName.ToUpper();
            PhoneNumber = phoneNumber;
            Email = email.ToUpper();
            Password = password;
            Address = address;
            CNPJ = string.IsNullOrEmpty(cNPJ) == true || string.IsNullOrWhiteSpace(cNPJ) == true ? null : cNPJ;
            Prices = priceEntity;
            OpenTime = openTime;
            GoogleMapsSource = string.IsNullOrEmpty(googleMapsSource) == true || string.IsNullOrWhiteSpace(googleMapsSource) == true ? null : googleMapsSource;
            CloseTime = closeTime;
        }
        public UserEntity()
        {

        }
    }
}