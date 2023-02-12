using Hair.Domain.Common;

namespace Hair.Domain.Entities
{
    public class BarberEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public double Salary { get; set; }
        public AddressEntity Adress { get; set; }
        public bool Hired { get; set; }
        public Guid JobSaloonId { get; set; }
        public string JobSaloonName { get; set; }

        public BarberEntity(string name, string? phoneNumber, string? email, double salary, AddressEntity adress, bool hired, Guid jobSaloonId, string jobSaloonName)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            Adress = adress;
            Adress.Complement = adress.Complement;
            Hired = hired;
            JobSaloonId = jobSaloonId;
            JobSaloonName = jobSaloonName;
        }
    }
}
