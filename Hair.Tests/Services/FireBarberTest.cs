using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class FireBarberTest
    {
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
        private readonly FireBarberService _service;
        private FireBarberDto _dto;
        private BarberEntity _barber;
        private HaircutPriceEntity _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private UserEntity _user;

        public FireBarberTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", new AddressEntity("Rua das Palmeiras",
                "666", "Blumenau", "Santa Catarina", ","),
                "400022884", _haircutPrice, DateTime.Now, null, DateTime.Now.AddHours(4));
            _service = new(_barberRepositoryMock.Object);
            _barber = new("carlos", null, null, 2000, new AddressEntity("Rua das Palmeiras",
                "666", "Blumenau", "Santa Catarina", ","), true, _user.Id, _user.SaloonName);
            _dto = new(_user.Id, _barber.Id, _barber.Name, _barber.Email, _barber.SaloonName);
        }

        [Fact]
        public void FireBarber_ShouldFail_WhenBarberNotFound()
        {
            // Arrange
            _barberRepositoryMock.Reset(); 
            _barberRepositoryMock.Setup(x => x.GetById(_barber.Id)).Returns((BarberEntity)null);

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