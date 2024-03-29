﻿namespace Hair.Application.Dto
{
    public class RegisterDto
    {
        public double HairPrice { get; set; }
        public double? BeardPrice { get; set; }
        public double? MustachePrice { get; set; }
        public string StreetName { get; set; }
        public string SaloonNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Complement { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CNPJ { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SaloonName { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string? GoogleMapsSource { get; set; }
        public string CEP { get; set; }

        public RegisterDto(double hair, double? beard, double? mustache, string street, string number, string city, string state,
            string? complement, string phoneNumber, string email, string? cNPJ, string name, string password, string saloonName,
            string openTime, string? googleMapsSource, string closeTime, string cEP)
        {
            HairPrice = hair;
            BeardPrice = beard;
            MustachePrice = mustache;
            StreetName = street;
            SaloonNumber = number;
            City = city;
            State = state;
            Complement = complement;
            PhoneNumber = phoneNumber;
            Email = email;
            CNPJ = cNPJ;
            Name = name;
            Password = password;
            SaloonName = saloonName;
            OpenTime = openTime;
            CloseTime = closeTime;
            GoogleMapsSource = googleMapsSource;
            CEP = cEP;
        }

        public RegisterDto()
        {

        }
    }
}