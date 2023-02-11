using Hair.Domain.Entities;

namespace Hair.Application.Dto
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressEntity Address { get; set; }
        public HaircutePriceEntity HaircutePrice{ get; set; }
        public string CNPJ { get; set; }
        public string OwnerName { get; set; }
        public string Password { get; set; }
        public string SaloonName { get; set; }

     
    }
}