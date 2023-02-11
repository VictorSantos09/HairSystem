using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class HaircuteEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public string HaircuteTime { get; set; }
        public bool Avaible { get; set; }
        public ClientEntity Client { get; set; }

        public HaircuteEntity(Guid saloonId, DateTime haircuteTime, bool avaible, ClientEntity client)
        {
            SaloonId = saloonId;
            HaircuteTime = haircuteTime.ToString();
            Avaible = avaible;
            Client = client;
        }
    }
}
