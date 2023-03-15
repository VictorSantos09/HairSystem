using FluentValidation.Results;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class RegisterServiceTest
    {
        private readonly Mock<IGetByEmail> _userRepositoryMock = new Mock<IGetByEmail>();
        private readonly ServiceProvider _provider;
        private readonly RegisterService _registerService;
        private RegisterDto _registerDto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "234", "Blumenau", "SC", null, "47991548956",
            "carlos@gmail.com", null, "carlos", "Carlos123!", "Carlos's", "14:50", null, "23:50", "78053680");
        private UserEntity _user;

        public RegisterServiceTest()
        {
            _provider = new ServiceProvider(new Mock<IBaseRepository<UserEntity>>(), new Mock<IBaseRepository<HaircutEntity>>(), 
                new Mock<IBaseRepository<BarberEntity>>(), _userRepositoryMock);

            _registerService = _provider.GetRegisterService();
            _user = new UserEntity(_registerDto.SaloonName, _registerDto.Name, _registerDto.PhoneNumber,
                _registerDto.Email, _registerDto.Password, null, null, null, TimeOnly.Parse(_registerDto.OpenTime), null, TimeOnly.Parse(_registerDto.CloseTime));
        }

        [Fact]
        public void Execute_WhenValidInput_ReturnsSuccess()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = 200;

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenInvalidEmail_ReturnsInvalidError()
        {
            //Arrange
            _registerDto.Email = "carlosgmail";

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenExistingEmail_ReturnsConflictError()
        {
            // Arrange
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns(_user);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_TooShortPassword_ReturnsInvalidError()
        {
            _registerDto.Password = "maria";
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenTooShortName_ReturnsInvalidError()
        {
            // Arrange
            _registerDto.Name = "Ana";
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingSaloonName_ReturnsNotNullError()
        {
            _registerDto.SaloonName = null;
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns(_user);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenPhoneNumberIsNullOrEmpty_ShouldReturnBaseDtoWithNotNullErrorMessage()
        {
            _registerDto.PhoneNumber = "";
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(_user);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = ValidationResultDto.GetStatusCode();

            // Assert
            Assert.Equal(expected, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldReturnInvalid_WhenOpenTimeIsInvalid()
        {
            // Arrange
            var invalidOpenTime = "24:00";
            _registerDto.OpenTime = invalidOpenTime;

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Horario de abertura");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldReturnInvalid_WhenCloseTimeIsInvalid()
        {
            // Arrange
            var invalidCloseTime = "24:00";
            _registerDto.CloseTime = invalidCloseTime;

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Horario de fechamento");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}