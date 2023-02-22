using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using System.Threading;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class FireBarberTest
    {
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
        private readonly FireBarberService _service;
        private GlobalUser _globalUser = new();
        private FireBarberDto _dto;
        private UserEntity _user;
        private BarberEntity _barber;

        public FireBarberTest()
        {
            _service = new(_barberRepositoryMock.Object);
             _user = _globalUser.GetGlobalUser();
            _barber = _globalUser.GetBarber();
            _dto = new(_user.Id, _barber.Id, _barber.Name, _barber.Email, _barber.SaloonName);
        }

        [Fact]
        public void FireBarber_ShouldFail_WhenBarberNotFound()
        {
            // Arrange
            _barberRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));


            // Act
            var actual = _service.FireBarber(_dto);
            var expected = BaseDtoExtension.NotFound("Barbeiro");


            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);

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