using Hair.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hair.Application.Dto
{
    public class HireBarberDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid SaloonId { get; set; }
        [MinLength(9)]
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [Required]
        public double Salary { get; set; }
        public AddressEntity Adress { get; set; }
        public bool Confirmed { get; set; }

        public HireBarberDto(string name, string? phoneNumber, string? email, double salary, AddressEntity adress, Guid saloonId, bool confirmed)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            Adress = adress;
            SaloonId = saloonId;
            Confirmed = confirmed;
        }
    }
}
