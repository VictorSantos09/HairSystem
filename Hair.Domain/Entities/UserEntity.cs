using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do usuário
    /// </summary>
    public class UserEntity : IUser
    {
        public Guid Id { get; set; }
        public string SaloonName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string Password { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string? GoogleMapsSource { get; set; }
        public IAddress Address { get; set; } = new AddressEntity();
        public IHaircutPrice Prices { get; set; } = new HaircutPriceEntity();
        public List<IHaircut> Haircuts { get; set; } = new();
        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string password,
            IAddress address, string? cNPJ, IHaircutPrice priceEntity, DateTime openTime, string? googleMapsSource, DateTime closeTime)
        {
            Id = Guid.NewGuid();
            SaloonName = saloonName.ToUpper();
            OwnerName = ownerName.ToUpper();
            PhoneNumber = phoneNumber;
            Email = email.ToUpper();
            Password = password;
            Address = address;
            CNPJ = cNPJ;
            Prices = priceEntity;
            OpenTime = openTime;
            GoogleMapsSource = googleMapsSource;
            CloseTime = closeTime;
        }
        public UserEntity()
        {

        }
    }
}