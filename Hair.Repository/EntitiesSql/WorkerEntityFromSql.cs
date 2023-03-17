using Hair.Domain.Entities;
using System;

namespace Hair.Repository.EntitiesSql
{
    internal class WorkerEntityFromSql : BaseEntity
    {
        /// <summary>
        /// 
        /// Nome do funcionário.
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// Telefone do funcionário.
        /// 
        /// </summary>
        public string Phone_Number { get; set; }
        /// <summary>
        /// 
        /// Email do funcionário.
        /// 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 
        /// Salário do funcionário.
        /// 
        /// </summary>
        public float Salary { get; set; }
        /// <summary>
        /// 
        /// Endereço do funcionário.
        /// 
        /// </summary>
        public AddressEntity Address { get; set; }
        /// <summary>
        /// 
        /// Id do usuário no qual o funcionário trabalha.
        /// 
        /// </summary>
        public Guid User_ID { get; set; }
        /// <summary>
        /// 
        /// Nome do salão no qual o funcionário trabalha.
        /// 
        /// </summary>
        public string Saloon_Name { get; set; }
    }
}
