using Hair.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hair.Application.Dto
{
    public class ChangeBarberAdressDto
    {
        public Guid SaloonId { get; set; }
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public AdressEntity NewAdress { get; set; }

        public ChangeBarberAdressDto(Guid saloonId, Guid barberId, string barberName, AdressEntity newAdress)
        {
            SaloonId = saloonId;
            BarberId = barberId;
            BarberName = barberName;
            NewAdress = newAdress;
        }
    }
}
