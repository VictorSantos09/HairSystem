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
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<HaircutEntity>> _haircutRepositoryMock = new Mock<IBaseRepository<HaircutEntity>>();
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();

        private readonly Mock<IGetByEmail> _IGetByEmailMock = new Mock<IGetByEmail>();

        private readonly IValidator<AddressEntity> _addressValidator = new AddressValidator();
        private readonly IValidator<ClientEntity> _clientValidator = new ClientValidator();
        private readonly IValidator<HaircutPriceEntity> _priceValidator = new HaircutPriceValidator();
        private readonly IValidator<UserEntity> _userValidator;
        private readonly IValidator<HaircutEntity> _haircutValidator;
        private readonly IValidator<BarberEntity> _barberValidator;

        public ServiceProvider()
        {
            _haircutValidator = new HaircutValidator(_clientValidator);
            _userValidator = new UserValidator(_addressValidator, _priceValidator);
        }

        public RegisterService GetRegisterService() => new RegisterService(_IGetByEmailMock.Object, _userValidator);

        public LoginService GetLoginService() => new LoginService(_IGetByEmailMock.Object);

        public ScheduleHaircutService GetScheduleHaircutService() => new ScheduleHaircutService(_userRepositoryMock.Object,
            _haircutRepositoryMock.Object, _haircutValidator);

        public ManagmentWorkerService GetManagmentWorkerService() => new ManagmentWorkerService(_userRepositoryMock.Object,
            _barberRepositoryMock.Object, _barberValidator);
    }
}
