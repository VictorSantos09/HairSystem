namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração do funcionário.
    /// 
    /// </summary>
    public class WorkerEntity : BaseEntity
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
        public string PhoneNumber { get; set; }
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
        public Guid UserID { get; set; }
        /// <summary>
        /// 
        /// Nome do salão no qual o funcionário trabalha.
        /// 
        /// </summary>
        public string SaloonName { get; set; }

        public WorkerEntity(string name, string phoneNumber, string? email, float salary, AddressEntity address, Guid userID, string saloonName)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            Address = address;
            UserID = userID;
            SaloonName = saloonName;
        }

        public WorkerEntity()
        {

        }
    }
}