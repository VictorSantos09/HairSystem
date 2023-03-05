namespace Hair.Application.Dto
{
    public class HireBarberDto
    {
        public string Name { get; set; }
        public Guid SaloonId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public double Salary { get; set; }
        public string BarberStreet { get; set; }
        public string BarberHouseNumber { get; set; }
        public string? BarberHouseComplement { get; set; }
        public string BarberCity { get; set; }
        public string BarberState { get; set; }
        public bool Confirmed { get; set; }
        public string CEP { get; set; }

        public HireBarberDto(string name, Guid saloonId, string? phoneNumber, string? email, double salary, string barberStreet,
            string barberHouseNumber, string? barberHouseComplement, string barberCity, string barberState, bool confirmed, string cEP)
        {
            Name = name;
            SaloonId = saloonId;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            BarberStreet = barberStreet;
            BarberHouseNumber = barberHouseNumber;
            BarberHouseComplement = barberHouseComplement;
            BarberCity = barberCity;
            BarberState = barberState;
            Confirmed = confirmed;
            CEP = cEP;
        }
    }
}
