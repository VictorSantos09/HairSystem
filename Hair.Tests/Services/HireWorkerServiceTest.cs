using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class HireWorkerServiceTest
    {
        private readonly Mock<IBaseRepository<IUser>> _userRepositoryMock = new Mock<IBaseRepository<IUser>>();
        private readonly Mock<IBaseRepository<IBarber>> _barberRepositoryMock = new Mock<IBaseRepository<IBarber>>();
        private readonly HireBarberService _service;
        private HireBarberDto _dto;
        private IHaircutPrice _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private IUser _user;
        public HireWorkerServiceTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", new AddressEntity(),
                null, _haircutPrice, DateTime.Now, null, DateTime.Now.AddHours(4));
            _service = new(_userRepositoryMock.Object, _barberRepositoryMock.Object);
            _dto = new HireBarberDto("Carlos", _user.Id, "047335478456", "carlos@gmail.com", 2000, "Rua Maria Alberta", "54", "", "Blumenau", "SC", true);
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
            _userRepositoryMock.Setup(x => x.GetById(_user.Id)).Returns(_user);
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