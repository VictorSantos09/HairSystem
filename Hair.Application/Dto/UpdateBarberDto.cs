using Hair.Domain.Entities;

namespace Hair.Application.Dto
{
    public class UpdateBarberDto
    {
        public Guid UserId { get; set; }
        public string BarberName { get; set; }
        public string? BarberEmail { get; set; }
        public string? BarberPhoneNumber { get; set; }
        public double BarberSalary { get; set; }
        public AddressEntity NewAddress { get; set; }
        public string? NewEmail { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string NewName { get; set; }
        public double NewSalary { get; set; }

        public UpdateBarberDto(Guid userId, string barberName, string? barberEmail, string? barberPhoneNumber, double barberSalary, 
            AddressEntity newAddress, string? newEmail, string? newPhoneNumber, string newName, double newSalary)
        {
            UserId = userId;
            BarberName = barberName;
            BarberEmail = barberEmail;
            BarberPhoneNumber = barberPhoneNumber;
            BarberSalary = barberSalary;
            NewAddress = newAddress;
            NewEmail = newEmail;
            NewPhoneNumber = newPhoneNumber;
            NewName = newName;
            NewSalary = newSalary;
        }
    }
}