using Hair.Domain.Common;
using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do barbeiro
    /// </summary>
    public class BarberEntity : BaseEntity, IBarber
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public double Salary { get; set; }
        public IAddress Address { get; set; } = new AddressEntity();
        public bool Hired { get; set; }
        public Guid SaloonId { get; set; }
        public string SaloonName { get; set; }

        public BarberEntity(string name, string? phoneNumber, string? email, double salary, IAddress adress, bool hired, Guid jobSaloonId, string jobSaloonName)
        {
            Id = Guid.NewGuid();
            Name = name.ToUpper();
            PhoneNumber = phoneNumber;
            Email = email.ToUpper();
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
