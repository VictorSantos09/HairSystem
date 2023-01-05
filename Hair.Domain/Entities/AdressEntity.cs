﻿namespace Hair.Domain.Entities
{
    public class AdressEntity
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Complement { get; set; }
        public AdressEntity(string street, string number, string city, string state, string? complement)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Complement = complement;
        }
    }
}