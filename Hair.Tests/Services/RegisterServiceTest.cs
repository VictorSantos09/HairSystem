using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Services.UserCases.UserAccountManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;
using Hair.Tests.Builders;
using Moq;

namespace Hair.Tests.Services
{
    public class RegisterServiceTest
    {
        private readonly int _Expected = ValidationResultDto.GetStatusCode();
        private readonly Mock<IGetByEmailDbContext> _userRepositoryMock = new Mock<IGetByEmailDbContext>();
        private readonly RegisterService _registerService;
        private RegisterDto _sucessDto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "234", "Blumenau", "SC", null, "47991548956",
            "carlos@gmail.com", null, "carlos", "Carlos123!", "Carlos's", "14:50", null, "23:50", "78053680");
        private UserEntity _user;

        public RegisterServiceTest()
        {
            _registerService = ServiceBuilder.InstanceRegister(_userRepositoryMock);

            _user = new UserEntity(_sucessDto.SaloonName, _sucessDto.UserName, _sucessDto.PhoneNumber,
                _sucessDto.Email, _sucessDto.Password, null, null, null, TimeOnly.Parse(_sucessDto.OpenTime), null, TimeOnly.Parse(_sucessDto.CloseTime));
        }

        [Fact]
        public void Execute_WhenValidInput_ReturnsSuccess()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_sucessDto.Email, _sucessDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenInvalidEmail_ReturnsInvalidError()
        {
            //Arrange
            _sucessDto.Email = "carlosgmail";

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenExistingEmail_ReturnsConflictError()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_sucessDto.Email, _sucessDto.Password)).Returns(_user);

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_TooShortPassword_ReturnsInvalidError()
        {
            _sucessDto.Password = "maria";
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_sucessDto.Email, _sucessDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Register(_sucessDto);

            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenTooShortName_ReturnsInvalidError()
        {
            // Arrange
            _sucessDto.UserName = "Ana";
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_sucessDto.Email, _sucessDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingSaloonName_ReturnsNotNullError()
        {
            _sucessDto.SaloonName = null;
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_sucessDto.Email, _sucessDto.Password)).Returns(_user);

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenPhoneNumberIsNullOrEmpty_ShouldReturnBaseDtoWithNotNullErrorMessage()
        {
            _sucessDto.PhoneNumber = "";
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(_user);

            // Act
            var actual = _registerService.Register(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldReturnInvalid_WhenOpenTimeIsInvalid()
        {
            // Arrange
            var invalidOpenTime = "24:00";
            _sucessDto.OpenTime = invalidOpenTime;

            // Act
            var actual = _registerService.Register(_sucessDto);
            var _Expected = BaseDtoExtension.Invalid("Horario de abertura");

            // Assert
            Assert.Equal(_Expected._Message, actual._Message);
            Assert.Equal(_Expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldReturnInvalid_WhenCloseTimeIsInvalid()
        {
            // Arrange
            var invalidCloseTime = "24:00";
            _sucessDto.CloseTime = invalidCloseTime;

            // Act
            var actual = _registerService.Register(_sucessDto);
            var _Expected = BaseDtoExtension.Invalid("Horario de fechamento");

            // Assert
            Assert.Equal(_Expected._Message, actual._Message);
            Assert.Equal(_Expected._StatusCode, actual._StatusCode);
        }
    }
}