using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class HaircuteEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        [Required]
        public DateTime HaircuteTime { get; set; }
        [Required]
        public bool Avaible { get; set; }
        [Required]
        public ClientEntity Client { get; set; }

        public HaircuteEntity(Guid saloonId, DateTime haircuteTime, bool avaible, ClientEntity client)
        {
            SaloonId = saloonId;
            HaircuteTime = haircuteTime;
            Avaible = avaible;
            Client.Name = client.Name;
            Client.Email = client.Email;
            Client.PhoneNumber = client.PhoneNumber;
        }
    }
}
