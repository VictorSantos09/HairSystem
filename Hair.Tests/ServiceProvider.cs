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
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock;
        private readonly Mock<IBaseRepository<HaircutEntity>> _haircutRepositoryMock;
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock;

        private readonly Mock<IGetByEmail> _IGetByEmailMock = new Mock<IGetByEmail>();

        private readonly IValidator<AddressEntity> _addressValidator = new AddressValidator();
        private readonly IValidator<ClientEntity> _clientValidator = new ClientValidator();
        private readonly IValidator<HaircutPriceEntity> _priceValidator = new HaircutPriceValidator();
        private readonly IValidator<UserEntity> _userValidator;
        private readonly IValidator<HaircutEntity> _haircutValidator;
        private readonly IValidator<BarberEntity> _barberValidator;

        public ServiceProvider(Mock<IBaseRepository<UserEntity>> userRepositoryMock, Mock<IBaseRepository<HaircutEntity>> haircutRepositoryMock,
            Mock<IBaseRepository<BarberEntity>> barberRepositoryMock, Mock<IGetByEmail> iGetByEmailMock)
        {
            _haircutValidator = new HaircutValidator(_clientValidator);
            _userValidator = new UserValidator(_addressValidator, _priceValidator);
            _userRepositoryMock = userRepositoryMock;
            _haircutRepositoryMock = haircutRepositoryMock;
            _barberRepositoryMock = barberRepositoryMock;
            _IGetByEmailMock = iGetByEmailMock;
        }

        public RegisterService GetRegisterService() => new RegisterService(_IGetByEmailMock.Object, _userValidator);

        public LoginService GetLoginService() => new LoginService(_IGetByEmailMock.Object);

        public ScheduleHaircutService GetScheduleHaircutService() => new ScheduleHaircutService(_userRepositoryMock.Object,
            _haircutRepositoryMock.Object, _haircutValidator);

        public ManagmentWorkerService GetManagmentWorkerService() => new ManagmentWorkerService(_userRepositoryMock.Object,
            _barberRepositoryMock.Object, _barberValidator);
    }
}
