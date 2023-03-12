using Hair.Domain.Entities;

namespace Hair.Repository
{
    internal class UserEntityFromSql : BaseEntity
    {
        public string Saloon_Name { get; set; }
        public byte[] Owner_Name { get; set; }
        public byte[] Phone_Number { get; set; }
        public byte[] Email { get; set; }
        public byte[]? CNPJ { get; set; }
        public byte[] Password { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public string? Google_Maps_Source { get; set; }
        public AddressEntity Address { get; set; } = new AddressEntity();
        public HaircutPriceEntity Prices { get; set; } = new HaircutPriceEntity();
        public List<HaircutEntity> Haircuts { get; set; } = new();

        public UserEntityFromSql(string saloonName, byte[] ownerName, byte[] phoneNumber, byte[] email, byte[]? cNPJ, byte[] password, TimeOnly openTime,
            TimeOnly closeTime, string? googleMapsSource,
            AddressEntity address, HaircutPriceEntity prices, List<HaircutEntity> haircuts)
        {
            Saloon_Name = saloonName;
            Owner_Name = ownerName;
            Phone_Number = phoneNumber;
            Email = email;
            CNPJ = cNPJ;
            Password = password;
            OpenTime = openTime;
            CloseTime = closeTime;
            Google_Maps_Source = googleMapsSource;
            Address = address;
            Prices = prices;
            Haircuts = haircuts;
        }

        public UserEntityFromSql()
        {

        }
    }
}
