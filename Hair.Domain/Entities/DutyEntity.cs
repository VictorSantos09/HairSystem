using System;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração da prestação de serviço para o cliente
    /// 
    /// </summary>
    public class DutyEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Id do usuário.
        /// 
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// 
        /// Horário do serviço.
        /// 
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Cliente agendado.
        /// </summary>
        public ClientEntity Client { get; set; } = new ClientEntity();

        public DutyEntity(Guid userID, DateTime date, ClientEntity client)
        {
            UserID = userID;
            Date = date;
            Client = client;
        }

        public DutyEntity()
        {

        }
    }
}
