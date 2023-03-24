using Hair.Application.Extensions;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.CRUD;
using Moq;

namespace Hair.Tests.Services
{
    public class VisualizeEmployeeDataServiceTest
    {
        private readonly Mock<IApplicationDbContext<EmployeeEntity>> _employeeRepositoryMock = new Mock<IApplicationDbContext<EmployeeEntity>>();
        private readonly Mock<IGetByEmailDbContext> _userRepositoryMock = new Mock<IGetByEmailDbContext>();
        private readonly ViewEmployeeDataService _service;
        private UserEntity _user = new UserEntity { Email = "Carlos@gmail.com", Password = "carlos123" };

        public VisualizeEmployeeDataServiceTest()
        {
            _service = new ViewEmployeeDataService(_employeeRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public void GetEmployeeData_ShouldReturnListOfBarbers_WhenValidUserIsProvided()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_user.Email, _user.Password)).Returns(_user);

            var jobSaloonId = Guid.NewGuid();
            var mockAdress = new AddressEntity("Rua das Palmeiras", "222", "Blumenau", "Santa Catarina", null, "456487895", _user.Id);

            var barbers = new List<EmployeeEntity>
            {
                new WorkerEntity("TestName", "TestPhoneNumber", "TestEmail", 200, mockAdress, true, jobSaloonId, "TestSaloon"),
                new WorkerEntity("TestName", "TestPhoneNumber2", "TestEmail2", 200, mockAdress, true, jobSaloonId, "TestSaloon2"),
            };

            _employeeRepositoryMock.Setup(repo => repo.GetAll()).Returns(barbers);

            // Act
            var result = _service.GetEmployeeData(_user.Email, _user.Password);

            // Assert
            Assert.Equal("Relação de barbeiros.", result._Message);
            Assert.Equal(200, result._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShouldntNotProceed_WhenNullEmail()
        {
            // Arrange
            var email = "";

            // Act
            var actual = _service.GetEmployeeData(email, "carlos");
            var expected = BaseDtoExtension.Invalid("Email não informado.");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShouldntNotProceed_WhenNullName()
        {
            // Arrange
            var name = "";

            // Act
            var actual = _service.GetEmployeeData("carlos@gmail.com", name);
            var expected = BaseDtoExtension.Invalid("Senha não informada.");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShoudntProceed_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(_user);

            // Act
            var actual = _service.GetEmployeeData(_user.Email, _user.Password);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShouldBeSucess_WhenNoEmployee()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByEmail(_user.Email, _user.Password)).Returns(_user);
            _employeeRepositoryMock.Setup(x => x.GetAll()).Returns(new List<EmployeeEntity>());

            // Act
            var actual = _service.GetEmployeeData(_user.Email, _user.Password);
            var expected = BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}
