using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Tests.Builders;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class HireWorkerServiceTest
    {
        private readonly int _Expected = ValidationResultDto.GetStatusCode();
        private readonly Mock<IApplicationDbContext<UserEntity>> _userRepositoryMock = new Mock<IApplicationDbContext<UserEntity>>();
        private readonly Mock<IApplicationDbContext<EmployeeEntity>> _barberRepositoryMock = new Mock<IApplicationDbContext<EmployeeEntity>>();
        private readonly CreateEmployeeService _service;
        private CreateEmployeeDto _dto;
        private UserEntity _user;
        private ServiceBuilder _serviceBuilder = new ServiceBuilder();
        public HireWorkerServiceTest()
        {
            _user = new UserEntity();

            _service = _serviceBuilder.InstanceHireWorker(_userRepositoryMock, _barberRepositoryMock);

            _dto = new HireBarberDto("Carlos", _user.Id, "047335478456", "carlos@gmail.com", 2000, "Rua Maria Alberta", "54", "", "Blumenau", "SC", true, "458789520");
        }

        [Fact]
        public void HireNewBarber_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.Create(_dto);

            // Assert
            Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenConfirmedFalse()
        {
            // Arrange
            _dto.Confirmed = false;

            // Act
            var actual = _service.Create(_dto);

            // Assert
            Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenDtoDataOk()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_user.Id)).Returns(_user);
            _barberRepositoryMock.Setup(x => x.Create(It.IsAny<EmployeeEntity>()));

            // Act
            var actual = _service.Create(_dto);
            var expected = BaseDtoExtension.Create(200, $"{_dto.Name} foi registrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(_Expected, actual._StatusCode);
        }
    }
}