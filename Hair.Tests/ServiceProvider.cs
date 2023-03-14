using FluentValidation;
using Hair.Application.Services;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests
{
    internal class ServiceProvider
    {
        private readonly Mock<IGetByEmail> _userRepositoryMock = new Mock<IGetByEmail>();
        private readonly IValidator<AddressEntity> _addressValidator = new AddressValidator();
        private readonly IValidator<ClientEntity> _clientValidator = new ClientValidator();
        private readonly IValidator<HaircutPriceEntity> _priceValidator = new HaircutPriceValidator();
        private readonly IValidator<UserEntity> _userValidator;

        public ServiceProvider()
        {
            _userValidator = new UserValidator(_addressValidator, _priceValidator);
        }

        public RegisterService GetRegisterService() => new RegisterService(_userRepositoryMock.Object, _userValidator);
    }
}
