using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using Xunit;

namespace Hair.Tests.Services
{
    public class VisualizeEmployeeDataServiceTest
    {
        private readonly Mock<IBaseRepository<BarberEntity>> _employeeRepositoryMock;
        private readonly Mock<IGetByEmail> _userRepositoryMock;
        private readonly VisualizeEmployeeDataService _service;
        private UserEntity _user;

        public VisualizeEmployeeDataServiceTest()
        {
            _employeeRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
            _userRepositoryMock = new Mock<IGetByEmail>();
            _service = new VisualizeEmployeeDataService(_employeeRepositoryMock.Object, _userRepositoryMock.Object);
            _user = new UserEntity { Email = "Carlos@gmail.com", Password = "carlos123" };
        }

        [Fact]
        public void GetEmployeeData_ShouldReturnListOfBarbers_WhenValidUserIsProvided()
        {
            // Arrange

            _userRepositoryMock.Setup(repo => repo.GetByEmail(_user.Email, _user.Password)).Returns(_user);

            var jobSaloonId = Guid.NewGuid();
            var mockAdress = new AddressEntity("Rua das Palmeiras", "222", "Blumenau", "Santa Catarina", null);

            var barbers = new List<BarberEntity>
            {
                new BarberEntity("TestName", "TestPhoneNumber", "TestEmail", 200, mockAdress, true, jobSaloonId, "TestSaloon"),
                new BarberEntity("TestName", "TestPhoneNumber2", "TestEmail2", 200, mockAdress, true, jobSaloonId, "TestSaloon2"),
            };

            _employeeRepositoryMock.Setup(repo => repo.GetAll()).Returns(barbers);

            // Act
            var result = _service.GetEmployeeData(_user.Email, _user.Password);

            // Assert
            Assert.Equal(200, result._StatusCode);
            Assert.Equal("Relação de barbeiros.", result._Message);

            var barbersResult = Assert.IsType<List<BarberEntity>>(result._Data);
            Assert.Equal(2, barbersResult.Count);

            foreach (var barber in barbersResult)
            {
                Assert.Equal(jobSaloonId, barber.JobSaloonId);
            }
        }

        [Fact]
        public void GetEmployeeData_ShouldntNotProceed_WhenNullEmail()
        {
            var actual = _service.GetEmployeeData(null, "carlos");

            var expected = BaseDtoExtension.Invalid("Email não informado.");

            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShouldntNotProceed_WhenNullName()
        {
            var actual = _service.GetEmployeeData("carlos@gmail.com", null);

            var expected = BaseDtoExtension.Invalid("Senha não informada.");

            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShoudntProceed_WhenUserNotFound()
        {
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(_user);

            var actual = _service.GetEmployeeData(_user.Email, _user.Password);

            var expected = BaseDtoExtension.NotFound();

            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void GetEmployeeData_ShouldBeSucess_WhenNoEmployee()
        {
            _userRepositoryMock.Setup(x => x.GetByEmail(_user.Email, _user.Password)).Returns(_user);
            _employeeRepositoryMock.Setup(x => x.GetAll()).Returns(new List<BarberEntity>());

            var actual = _service.GetEmployeeData(_user.Email, _user.Password);

            var expected = BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}
