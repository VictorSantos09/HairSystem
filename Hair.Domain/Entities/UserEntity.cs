using Hair.Domain.Common;
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
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
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
            Adress = adress;
            CNPJ = cNPJ;
            PriceEntity = priceEntity;
        }
    }
}
