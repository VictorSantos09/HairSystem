using Hair.Domain.Entities;

namespace Hair.Repository.EntitiesSql
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

        public UserEntityFromSql(string saloon_Name, byte[] owner_Name, byte[] phone_Number, 
            byte[] email, byte[]? cNPJ, byte[] password, TimeOnly openTime, TimeOnly closeTime, string? google_Maps_Source, AddressEntity address)
        {
            Saloon_Name = saloon_Name;
            Owner_Name = owner_Name;
            Phone_Number = phone_Number;
            Email = email;
            CNPJ = cNPJ;
            Password = password;
            OpenTime = openTime;
            CloseTime = closeTime;
            Google_Maps_Source = google_Maps_Source;
            Address = address;
        }

        public UserEntityFromSql()
        {

        }
    }
}
