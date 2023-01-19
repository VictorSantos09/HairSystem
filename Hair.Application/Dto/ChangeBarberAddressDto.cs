using Hair.Domain.Entities;

namespace Hair.Application.Dto
{
    public class ChangeBarberAddressDto
    {
        public Guid SaloonId { get; set; }
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public AddressEntity NewAdress { get; set; }

        public ChangeBarberAddressDto(Guid saloonId, Guid barberId, string barberName, AddressEntity newAdress)
        {
            SaloonId = saloonId;
            BarberId = barberId;
            BarberName = barberName;
            NewAdress = newAdress;
        }
    }
}
