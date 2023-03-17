using FluentValidation;
using Hair.Application.Validators;
using Hair.Domain.Entities;

namespace Hair.Tests.Builders
{
    internal sealed class ValidatorBuilder
    {
        private IValidator<UserEntity> _userValidator;
        private IValidator<AddressEntity> _addressValidator;
        private IValidator<ClientEntity> _clientValidator;
        private IValidator<HaircutPriceEntity> _priceValidator;
        private IValidator<DutyEntity> _haircutValidator;
        private IValidator<WorkerEntity> _barberValidator;
        private IValidator<ItemEntity> _saloonItemValidator;
        private IValidator<ImageEntity> _imageValidator;
        public ValidatorBuilder()
        {
            _addressValidator = new AddressValidator();
            _clientValidator = new ClientValidator();
            _priceValidator = new HaircutPriceValidator();
            _saloonItemValidator = new SaloonItemValidator();
            _imageValidator = new ImageValidator();
            _barberValidator = new BarberValidator(_addressValidator);
            _haircutValidator = new HaircutValidator(_clientValidator);
            _userValidator = new UserValidator(_addressValidator, _priceValidator);
        }

        public IValidator<UserEntity> InstanceUserValidator() => _userValidator;

        public IValidator<AddressEntity> InstanceAddressValidator() => _addressValidator;

        public IValidator<ClientEntity> InstanceClientValidator() => _clientValidator;

        public IValidator<HaircutPriceEntity> InstanceHaircutPriceValidator() => _priceValidator;

        public IValidator<WorkerEntity> InstanceBarberValidator() => _barberValidator;

        public IValidator<DutyEntity> InstanceHaircutValidator() => _haircutValidator;

        public IValidator<ImageEntity> InstanceImageValidator() => _imageValidator;

        public IValidator<ItemEntity> InstanceSaloonItemValidator() => _saloonItemValidator;

    }
}