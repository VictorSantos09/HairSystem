using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class AddressFactory
    {
        public AddressEntity Create() => new AddressEntity();
        public AddressEntity Create(StreetEntity street, CityEntity city, StateEntity state,
            CountryEntity country, string? complement, Guid userID, string fullAddress)
        {
            return new AddressEntity(street, city, state, country, complement, userID, fullAddress);
        }

    }
}
