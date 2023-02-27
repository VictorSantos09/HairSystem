namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do corte de cabelo
    /// </summary>
    public class HaircutEntity : BaseEntity
    {
        /// <summary>
        /// Id do salão
        /// </summary>
        public Guid SaloonId { get; set; }
        /// <summary>
        /// Horário do corte de cabelo
        /// </summary>
        public DateTime HaircuteTime { get; set; }
        /// <summary>
        /// Disponível
        /// </summary>
        public bool Avaible { get; set; }
        /// <summary>
        /// Cliente no qual agendou o corte
        /// </summary>
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
