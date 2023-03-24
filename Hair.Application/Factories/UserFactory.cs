using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class UserFactory
    {
        public UserEntity Create() => new UserEntity();
        public UserEntity Create(string saloonName, string ownerName, string phoneNumber, string email, string? cNPJ,
            string password, AddressEntity address, TimeOnly openTime, TimeOnly closeTime, string? googleMapsLocation)
        {
            return new UserEntity(saloonName, ownerName, phoneNumber, email, cNPJ, password, address, openTime, closeTime, googleMapsLocation);
        }
    }
}