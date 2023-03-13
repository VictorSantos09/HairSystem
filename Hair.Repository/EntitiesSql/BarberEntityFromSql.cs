using Hair.Domain.Entities;

namespace Hair.Repository.EntitiesSql
{
    internal class BarberEntityFromSql : BaseEntity
    {
        /// <summary>
        /// 
        /// Nome do barbeiro.
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// Telefone do barbeiro.
        /// 
        /// </summary>
        public string? Phone_Number { get; set; }
        /// <summary>
        /// 
        /// Email do barbeiro.
        /// 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 
        /// Salário do barbeiro.
        /// 
        /// </summary>
        public double Salary { get; set; }
        /// <summary>
        /// 
        /// Endereço do barbeiro.
        /// 
        /// </summary>
        public AddressEntity Address { get; set; } = new AddressEntity();
        /// <summary>
        /// 
        /// Contratado.
        /// 
        /// </summary>
        public bool Hired { get; set; }
        /// <summary>
        /// 
        /// Id do salão no qual o barbeiro trabalha.
        /// 
        /// </summary>
        public Guid Saloon_Id { get; set; }
        /// <summary>
        /// 
        /// Nome do salão no qual o barbeiro trabalha.
        /// 
        /// </summary>
        public string Saloon_Name { get; set; }
    }
}
