using Hair.Domain.Common;

namespace Hair.Domain.Entities
{
    public class HaircutEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public string HaircuteTime { get; set; }
        public bool Avaible { get; set; }
        public ClientEntity Client { get; set; }

        public HaircutEntity(Guid saloonId, string haircuteTime, bool avaible, ClientEntity client)
        {
            Id = Guid.NewGuid();
            SaloonId = saloonId;
            HaircuteTime = haircuteTime;
            Avaible = avaible;
            Client = client;
        }
    }
}
