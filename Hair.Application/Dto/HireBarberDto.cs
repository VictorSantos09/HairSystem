using Hair.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hair.Application.Dto
{
    public class HireBarberDto
    {
        public string Name { get; set; }
        public Guid SaloonId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
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
