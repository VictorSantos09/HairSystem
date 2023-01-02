using Domain.Entities;

namespace Hair.Domain.Entities
{
    public class HaircuteEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public DateTime HaircuteTime { get; set; }
        public bool Avaible { get; set; }
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
