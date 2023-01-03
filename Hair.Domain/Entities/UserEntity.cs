using Domain.Entities;

namespace Hair.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string SaloonName { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AdressEntity Adress { get; set; }
        public string? CNPJ { get; set; }
        public HaircutePriceEntity PriceEntity { get; set; }

        public UserEntity(string saloonName, string ownerName, string phoneNumber, string email, string password, AdressEntity adress, string? cNPJ, HaircutePriceEntity priceEntity)
        {
            Id = Guid.NewGuid();
            SaloonName = saloonName;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Adress.Street = adress.Street;
            Adress.Number = adress.Number;
            Adress.State = adress.State;
            Adress.City = adress.City;
            Adress.Complement = adress.Complement;
            CNPJ = cNPJ;
            PriceEntity.Hair = priceEntity.Hair;
            PriceEntity.Beard = priceEntity.Beard;
            PriceEntity.Mustache = priceEntity.Mustache;
        }
    }
}
