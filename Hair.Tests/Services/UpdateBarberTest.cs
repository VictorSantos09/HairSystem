using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class UpdateBarberTest
    {
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<WorkerEntity>> _barberRepositoryMock = new Mock<IBaseRepository<WorkerEntity>>();
        private readonly UpdateWorkerService _service;
        private UpdateWorkerDto _dto;
        private WorkerEntity _barber;
        private HaircutPriceEntity _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private UserEntity _user;
        private AddressEntity _address;

        public UpdateBarberTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", _address,
               null, _haircutPrice, TimeOnly.FromDateTime(DateTime.Now), null, TimeOnly.FromDateTime(DateTime.Now.AddHours(4)));

            _address = new AddressEntity("Rua das Palmeiras", "666", "Blumenau", "Santa Catarina", ",", "45231245", _user.Id);

            _barber = new WorkerEntity("Carlos", "017994578951", "victor@gmail.com", 2000, _address, true, _user.Id, _user.SaloonName);
            _service = new(_userRepositoryMock.Object, _barberRepositoryMock.Object, null);
            _dto = new(_user.Id, _barber.Name, _barber.Email, _barber.PhoneNumber, _barber.Salary, _address, "Carlos@gmail.com", "041991545235", "Carlos", 5000);
        }

        [Fact]
        public void Update_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Update_ShouldFail_WhenAnyBarberFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserID)).Returns(_user);
            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(new List<WorkerEntity>());

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.Create(404, "Nenhum barbeiro foi encontrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Update_ShouldFail_WhenNoneBarberToUpdateFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserID)).Returns(_user);

            var barbers = new List<WorkerEntity>();
            _barber.Name = "Jose";
            _barber.PhoneNumber = "047994565856";
            _dto.WorkerName = "Maria";
            barbers.Add(_barber);

            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(barbers);

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.NotFound("Barbeiro para atualizar");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Update_ShouldBeSucess_WhenAllOk()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserID)).Returns(_user);
            var barbers = new List<WorkerEntity>();
            barbers.Add(_barber);

            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(barbers);

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.Sucess($"Dados de {_dto.NewName.ToUpper()} atualizados");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}