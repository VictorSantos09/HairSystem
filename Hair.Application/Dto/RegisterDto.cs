namespace Hair.Application.Dto
{
    public class RegisterDto
    {
        public string StreetName { get; set; }
        public string SaloonNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Complement { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SaloonName { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string? GoogleMapsLocation { get; set; }
        public string CEP { get; set; }

        public RegisterDto(string streetName, string saloonNumber, string city, string state, string? complement, string phoneNumber, string email, string? cNPJ, 
            string userName, string password, string saloonName, string openTime, string closeTime, string? googleMapsLocation, string cEP)
        {
            StreetName = streetName;
            SaloonNumber = saloonNumber;
            City = city;
            State = state;
            Complement = complement;
            PhoneNumber = phoneNumber;
            Email = email;
            CNPJ = cNPJ;
            UserName = userName;
            Password = password;
            SaloonName = saloonName;
            OpenTime = openTime;
            CloseTime = closeTime;
            GoogleMapsLocation = googleMapsLocation;
            CEP = cEP;
        }

        public RegisterDto()
        {

        }
    }
}