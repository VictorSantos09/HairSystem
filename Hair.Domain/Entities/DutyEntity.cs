using System;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração da prestação de serviço para o cliente
    /// 
    /// </summary>
    public sealed class DutyEntity : BaseEntity
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
        public ClientEntity Client { get; set; }
        /// <summary>
        /// Tipo de tarefa a ser prestado
        /// </summary>
        public TaskTypeEntity TaskType { get; set; }

        public DutyEntity(Guid userID, DateTime date, ClientEntity client, TaskTypeEntity taskType)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Date = date;
            Client = client;
            TaskType = taskType;
        }

        public DutyEntity()
        {

        }
    }
}
