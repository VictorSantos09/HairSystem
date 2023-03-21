namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do funcionário.
    /// </summary>
    public sealed class EmployeeEntity : BaseEntity
    {
        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telefone do funcionário.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email do funcionário.
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Salário do funcionário.
        /// </summary>
        public float Salary { get; set; }
        /// <summary>
        /// Endereço do funcionário.
        /// </summary>
        public AddressEntity Address { get; set; }
        /// <summary>
        /// Id do usuário no qual o funcionário trabalha.
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// Tipo de função prestado pelo funcionário.
        /// </summary>
        public FunctionTypeEntity FunctionType { get; set; }

        public EmployeeEntity(string name, string phoneNumber, string? email, float salary, AddressEntity address, Guid userID, FunctionTypeEntity functionType)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            Address = address;
            UserID = userID;
            FunctionType = functionType;
        }

        public EmployeeEntity()
        {

        }
    }
}