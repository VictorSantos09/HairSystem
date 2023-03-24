using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Services.UserCases.UserAccountManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class LoginServiceTest
    {
        private readonly LoginService _service;
        private Mock<IGetByEmailDbContext> _userRepositoryMock = new Mock<IGetByEmailDbContext>();
        private LoginDto _dto = new("maria@gmail.com", "maria123");

        public LoginServiceTest()
        {
            _service = new(_userRepositoryMock.Object);
        }

        [Fact]
        public void CheckLogin_ShouldntBeSucess_WhenUserDoesntExists()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>()));

            // Act
            var actual = _service.Login(_dto);
            var expected = new BaseDto(404, "Usuario não encontrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void CheckLogin_ShouldntBeSucess_WhenNullData()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>()));
            var dto = new LoginDto(null, null);

            // Act
            var actual = _service.Login(dto);
            var expected = new BaseDto(406, "Email ou senha inválidos");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void CheckLogin_ShouldBeSucess_WhenUserExists()
        {
            // Arrange
            var user = new UserEntity();
            user.Email = "caio@gmail.com";
            user.Password = "caio12345";
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            // Act
            var actual = _service.Login(_dto);
            var expected = new BaseDto(200, "Login realizado com sucesso!", user.Id);

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}