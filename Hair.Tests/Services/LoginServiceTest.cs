using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class LoginServiceTest
    {
        private readonly LoginService _service;
        private Mock<IGetByEmail> _userRepositoryMock = new Mock<IGetByEmail>();
        private LoginDto _dto = new("maria@gmail.com", "maria123");

        public LoginServiceTest()
        {
            _service = new(_userRepositoryMock.Object);
        }

        [Fact]
        public void CheckLogin_ShouldntBeSucess_WhenUserDoesntExists()
        {
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>()));

            var actual = _service.CheckLogin(_dto);

            var expected = new BaseDto(404, "Usuario não encontrado");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);

        }

        [Fact]
        public void CheckLogin_ShouldntBeSucess_WhenNullData()
        {
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>()));

            var dto = new LoginDto(null, null);

            var actual = _service.CheckLogin(dto);

            var expected = new BaseDto(406, "Email ou senha inválidos");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void CheckLogin_ShouldBeSucess_WhenUserExists()
        {
            var user = new UserEntity();

            user.Email = "caio@gmail.com";
            user.Password = "caio12345";

            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            var actual = _service.CheckLogin(_dto);

            var expected = new BaseDto(200, "Login realizado com sucesso!", user.Id);

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}