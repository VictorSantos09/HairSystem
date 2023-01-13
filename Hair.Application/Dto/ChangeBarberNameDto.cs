using System.ComponentModel.DataAnnotations;

namespace Hair.Application.Dto
{
    public class ChangeBarberNameDto
    {
        [Required]
        public Guid BarberId { get; set; }
        [Required]
        public Guid SaloonId { get; set; }
        [Required]
        [MinLength(5)]
        public string NewName { get; set; }
        [Required]
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