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

        public VisualizeEmployeeDataServiceTest()
        {
            _employeeRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
            _userRepositoryMock = new Mock<IGetByEmail>();
            _service = new VisualizeEmployeeDataService(_employeeRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public void GetEmployeeData_ShouldReturnListOfBarbers_WhenValidUserIsProvided()
        {
            // Arrange
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Email = "user@test.com",
                Password = "password"
            };

            _userRepositoryMock.Setup(repo => repo.GetByEmail(user.Email, user.Password)).Returns(user);

            var jobSaloonId = Guid.NewGuid();
            var mockAdress = new AddressEntity("Rua das Palmeiras", "222", "Blumenau", "Santa Catarina", null);

            var barbers = new List<BarberEntity>
            {
                new BarberEntity("TestName", "TestPhoneNumber", "TestEmail", 200, mockAdress, true, jobSaloonId, "TestSaloon"),
                new BarberEntity("TestName", "TestPhoneNumber2", "TestEmail2", 200, mockAdress, true, jobSaloonId, "TestSaloon2"),
            };

            _employeeRepositoryMock.Setup(repo => repo.GetAll()).Returns(barbers);

            // Act
            var result = _service.GetEmployeeData(user.Email, user.Password);

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
    }
}
