using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string SaloonName { get; set; }
        [Required]
        [MinLength(5)]
        public string OwnerName { get; set; }
        [MinLength(9)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public AddressEntity Adress { get; set; }
        public string? CNPJ { get; set; }
        public HaircutePriceEntity PriceEntity { get; set; }
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
            PriceEntity = priceEntity;
        }
    }
}