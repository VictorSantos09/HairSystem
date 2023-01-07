using Hair.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class BarberEntity : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [Required]
        public double Salary { get; set; }
        public AddressEntity Adress { get; set; }
        [Required]
        public bool Hired { get; set; }
        [Required]
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
