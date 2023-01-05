using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class AdressEntity
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
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
