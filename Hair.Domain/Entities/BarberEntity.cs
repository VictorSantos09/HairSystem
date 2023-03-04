namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração do barbeiro.
    /// 
    /// </summary>
    public class BarberEntity : BaseEntity
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
        public string? PhoneNumber { get; set; }
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
        public Guid SaloonId { get; set; }
        /// <summary>
        /// 
        /// Nome do salão no qual o barbeiro trabalha.
        /// 
        /// </summary>
        public string SaloonName { get; set; }

        public BarberEntity(string name, string? phoneNumber, string? email, double salary, AddressEntity adress, bool hired, Guid jobSaloonId, string jobSaloonName)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            PhoneNumber = phoneNumber;
            Email = email == null ? null : email.ToUpper();
            Salary = salary;
            Address = adress;
            Hired = hired;
            SaloonId = jobSaloonId;
            SaloonName = jobSaloonName.ToUpper();
        }

        public BarberEntity()
        {

        }
    }
}