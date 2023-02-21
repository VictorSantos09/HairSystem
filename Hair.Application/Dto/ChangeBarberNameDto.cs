using System.ComponentModel.DataAnnotations;

namespace Hair.Application.Dto
{
    public class ChangeBarberNameDto
    {
        public Guid BarberId { get; set; }
        public Guid SaloonId { get; set; }
        public string NewName { get; set; }
        public string BarberName { get; set; }

        public ChangeBarberNameDto(Guid barberId, Guid saloonId, string newName, string barberName)
        {
            BarberId = barberId;
            SaloonId = saloonId;
            NewName = newName;
            BarberName = barberName;
        }
    }
}