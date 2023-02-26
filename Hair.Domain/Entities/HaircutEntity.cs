using Hair.Domain.Common;
using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do corte
    /// </summary>
    public class HaircutEntity : IHaircut
    {
        public Guid Id { get; set; }
        public Guid SaloonId { get; set; }
        public DateTime HaircuteTime { get; set; }
        public bool Avaible { get; set; }
        public IClient Client { get; set; } = new ClientEntity();

        public HaircutEntity(Guid saloonId, DateTime haircuteTime, bool avaible, IClient client)
        {
            Id = Guid.NewGuid();
            SaloonId = saloonId;
            HaircuteTime = haircuteTime;
            Avaible = avaible;
            Client = client;
        }

        public HaircutEntity()
        {

        }
    }
}
