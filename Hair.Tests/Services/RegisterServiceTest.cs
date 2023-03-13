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
        private readonly Mock<IGetByEmail> _userRepositoryMock;
        private readonly RegisterService _registerService;
        private RegisterDto _registerDto;

        public RegisterServiceTest()
        {
            _registerDto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "234", "Blumenau", "SC", null, "47991548956", "carlos@gmail.com", null, "carlos", "Carlos123!", "Carlos's", "14:50",
                null, "23:50", "78053680");
            _userRepositoryMock = new Mock<IGetByEmail>();
            _registerService = new RegisterService(_userRepositoryMock.Object, null);
        }

        [Fact]
        public void Execute_WhenValidInput_ReturnsSuccess()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Sucess("Conta Criada com sucesso");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
        }

        [Fact]
        public void Execute_WhenInvalidEmail_ReturnsInvalidError()
        {
            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Email inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenExistingEmail_ReturnsConflictError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns(new UserEntity());

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Usuário já registrado");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_TooShortPassword_ReturnsInvalidError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Senha muito curta");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenTooShortName_ReturnsInvalidError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Nome muito curto");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenInvalidHairPrice_ReturnsInvalidError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Valor do corte de cabelo inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingAddress_ReturnsNotNullError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.NotNull("Endereço");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingSaloonName_ReturnsNotNullError()
        {
            _userRepositoryMock.Setup(repo => repo.GetByEmail(_registerDto.Email, _registerDto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.NotNull("Nome do salão");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenPhoneNumberIsNullOrEmpty_ShouldReturnBaseDtoWithNotNullErrorMessage()
        {
            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(_registerDto);
            var expected = BaseDtoExtension.Invalid("Telefone não pode ser nulo");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldReturnInvalid_WhenOpenTimeIsInvalid()
        {
            // Arrange
            var invalidOpenTime = DateTime.Now.AddDays(-1);
            var dto = new RegisterDto(20, 20, 20, "Rua B", "22", "Guarapuava", "Paraná", "Atrás do mercado", "4785489647",
                "ALELUIA@GMAIL.COM", "123456789-10", "Patrícia", "znpkdwor35f", "LightSaloon", invalidOpenTime.ToString(), "abc.com",
                TimeOnly.FromDateTime(DateTime.Now.AddDays(20)).ToString(), "45874350");
            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Horário de abertura inválido");

            // Assert

            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}
