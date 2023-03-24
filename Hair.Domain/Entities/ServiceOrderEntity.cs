namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração da ordem de serviço para o cliente.
    /// 
    /// </summary>
    public sealed class ServiceOrderEntity : BaseEntity
    {
        /// <summary>
        /// Id do usuário.
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// Horário do serviço.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Cliente agendado.
        /// </summary>
        public ClientEntity Client { get; set; }
        /// <summary>
        /// Tipo de serviço a ser prestado
        /// </summary>
        public UserServiceTypeEntity TaskType { get; set; }

        public ServiceOrderEntity(Guid userID, DateTime date, ClientEntity client, UserServiceTypeEntity serviceType)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Date = date;
            Client = client;
            TaskType = serviceType;
        }

        public ServiceOrderEntity()
        {

        }
    }
}
