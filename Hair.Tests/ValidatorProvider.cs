using Hair.Application.Services;
using Hair.Application.Validators;

namespace Hair.Tests
{
    internal class ValidatorProvider
    {
        private UserValidator _userValidator;
        private AddressValidator _addressValidator;
        private ClientValidator _clientValidator;
        private HaircutPriceValidator _priceValidator;
        private BarberValidator _barberValidator;
        private HaircutValidator _haircutValidator;
        public ValidatorProvider()
        {
            _addressValidator = new AddressValidator();
            _clientValidator = new ClientValidator();
            _priceValidator = new HaircutPriceValidator();
            _barberValidator = new BarberValidator(_addressValidator);
            _haircutValidator = new HaircutValidator(_clientValidator);
            _userValidator = new UserValidator(_addressValidator, _priceValidator);
        }

        public UserValidator InstanceUserValidator() => _userValidator;

        public AddressValidator InstanceAddressValidator() => _addressValidator;

        public ClientValidator InstanceClientValidator() => _clientValidator;

        public HaircutPriceValidator InstanceHaircutPriceValidator() => _priceValidator;

        public BarberValidator InstanceBarberValidator() => _barberValidator;

        public HaircutValidator InstanceHaircutValidator() => _haircutValidator;

    }
}