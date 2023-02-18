using Hair.Domain.Entities;

namespace Hair.Application.Dto
{
    public class RegisterDto
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressEntity Address { get; set; }
        public HaircutPriceEntity HaircutePrice { get; set; }
        public string? CNPJ { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SaloonName { get; set; }

        public RegisterDto(string phoneNumber, string email, AddressEntity address, HaircutPriceEntity haircutePrice, string? cNPJ, string name, string password, string saloonName)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            HaircutePrice = haircutePrice;
            CNPJ = cNPJ;
            Name = name;
            Password = password;
            SaloonName = saloonName;
        }
    }
}