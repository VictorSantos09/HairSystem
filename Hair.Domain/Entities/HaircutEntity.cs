namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do corte
    /// </summary>
    public class HaircutEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public DateTime HaircuteTime { get; set; }
        public bool Avaible { get; set; }
        public ClientEntity Client { get; set; } = new ClientEntity();

        public HaircutEntity(Guid saloonId, DateTime haircuteTime, bool avaible, ClientEntity client)
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
