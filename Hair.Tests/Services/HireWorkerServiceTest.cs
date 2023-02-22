using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class HireWorkerServiceTest
    {
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
        private readonly GlobalUser _user = new();
        private readonly HireBarberService _service;
        private HireBarberDto _dto;
        public HireWorkerServiceTest()
        {
            _service = new(_userRepositoryMock.Object,_barberRepositoryMock.Object);    
            _dto = new HireBarberDto("Carlos", "047991547878", "carlos@gmail.com", 2000, _user.GetAdress(), _user.Id, true);
        }

        [Fact]
        public void HireNewBarber_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.HireNewbarber(_dto);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenConfirmedFalse()
        {
            // Arrange
            _dto.Confirmed = false;

            // Act
            var actual = _service.HireNewbarber(_dto);
            var expected = BaseDtoExtension.RequestCanceled();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenDtoDataOk()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_user.Id)).Returns(_user.GetGlobalUser());
            _barberRepositoryMock.Setup(x => x.Create(It.IsAny<BarberEntity>()));

            // Act
            var actual = _service.HireNewbarber(_dto);
            var expected = BaseDtoExtension.Create(200, $"{_dto.Name} foi registrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}