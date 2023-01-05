using Hair.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class BarberEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public double Salary { get; set; }
        public AdressEntity Adress { get; set; }
        [Required]
        public bool Hired { get; set; }

        public BarberEntity(string name, string phoneNumber, string email, double salary, AdressEntity adress, bool hired)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            Adress.Street = adress.Street;
            Adress.Number = adress.Number;
            Adress.State = adress.State;
            Adress.City = adress.City;
            Adress.Complement = adress.Complement;
            Hired = hired;
        }
    }
}
