using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class FireBarberTest
    {
        private readonly Mock<IBaseRepository<EmployeeEntity>> _barberRepositoryMock = new Mock<IBaseRepository<EmployeeEntity>>();
        private readonly DeleteEmployeeService _service;
        private FireWorkerDto _dto;
        private EmployeeEntity _barber;
        private HaircutPriceEntity _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private UserEntity _user;
        private AddressEntity _address;

        public FireBarberTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", _address,
                "400022884", _haircutPrice, TimeOnly.FromDateTime(DateTime.Now), null, TimeOnly.FromDateTime(DateTime.Now.AddHours(4)));

            _address = new AddressEntity("Rua das Palmeiras",
                "666", "Blumenau", "Santa Catarina", ",", "523156480", _user.Id);

            _service = new(_barberRepositoryMock.Object);

            _barber = new("carlos", null, null, 2000, _address, true, _user.Id, _user.SaloonName);

            _dto = new(_user.Id, _barber.Id, _barber.Name, _barber.Email, _barber.SaloonName);
        }

        [Fact]
        public void FireBarber_ShouldFail_WhenBarberNotFound()
        {
            // Arrange
            _barberRepositoryMock.Reset();
            _barberRepositoryMock.Setup(x => x.GetById(_barber.Id)).Returns((EmployeeEntity)null);

            // Act
            var actual = _service.FireBarber(_dto);
            var expected = BaseDtoExtension.NotFound("Barbeiro");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }


        [Fact]
        public void FireBarber_ShouldFail_WhenUnableToMatchBarber()
        {
            // Arrange
            _barber.Name = "Carlos";
            _barberRepositoryMock.Setup(x => x.GetById(_barber.Id)).Returns(_barber);

            // Act
            var actual = _service.FireBarber(_dto);
            var expected = BaseDtoExtension.Create(406, "Não foi possivel encontrar o barbeiro no salão");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void FireBarber_ShouldBeSucess_WhenValidData()
        {
            // Arrange
            _barberRepositoryMock.Setup(x => x.GetById(_barber.Id)).Returns(_barber);
            _barberRepositoryMock.Setup(x => x.Remove(_barber.Id));

            // Act
            var actual = _service.FireBarber(_dto);
            var expected = BaseDtoExtension.Sucess($"{_barber.Name} foi demitido");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}