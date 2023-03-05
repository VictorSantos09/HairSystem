using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class RegisterServiceTest
    {
        private readonly Mock<IGetByEmail> _userRepositoryMock;
        private readonly RegisterService _registerService;

        public RegisterServiceTest()
        {
            _userRepositoryMock = new Mock<IGetByEmail>();
            _registerService = new RegisterService(_userRepositoryMock.Object);
        }

        [Fact]
        public void Execute_WhenValidInput_ReturnsSuccess()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", "40028922", "banana@gmail.com", null, "Carlos", "banana",
                "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Sucess("Conta Criada com sucesso");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
        }

        [Fact]
        public void Execute_WhenInvalidEmail_ReturnsInvalidError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", "40028922", null, null, "Carlos", "banana",
               "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Email inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenExistingEmail_ReturnsConflictError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", "40028922", "banana@gmail.com", null, "Carlos", "banana",
              "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns(new UserEntity());

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Usuário já registrado");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_TooShortPassword_ReturnsInvalidError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", "40028922", "banana@gmail.com", null, "Carlos", "1",
             "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Senha muito curta");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenTooShortName_ReturnsInvalidError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", "40028922", "banana@gmail.com", null, "A", "banana",
             "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Nome muito curto");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenInvalidHairPrice_ReturnsInvalidError()
        {
            // Arrange
            var dto = new RegisterDto(-20, -20, -20, "Rua das Palmeiras", "69", "Blumenau", "SC", null, null, "banana@gmail.com", null, "Carlos", "banana",
                "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Valor do corte de cabelo inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingAddress_ReturnsNotNullError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, null, null, null, null, null, null, "cavalo@gmail.com", null, "Carla", "banana",
                "Carlinhair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.NotNull("Endereço");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenMissingSaloonName_ReturnsNotNullError()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "69", "Blumenau", "SC", "Ao lado da Blumob", "472823829", "banana@gmail.com", null, "Carlos", "banana",
              null, DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));


            _userRepositoryMock.Setup(repo => repo.GetByEmail(dto.Email, dto.Password)).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.NotNull("Nome do salão");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_WhenPhoneNumberIsNullOrEmpty_ShouldReturnBaseDtoWithNotNullErrorMessage()
        {
            // Arrange
            var dto = new RegisterDto(20, 20, 20, "Rua das Palmeiras", "49", "Blumenau", "SC", "Ao lado da Blumob", null, "banana@gmail.com", null, "Carlos", "banana",
                "CarlinHair", DateTime.Now.AddDays(3), null, DateTime.Now.AddDays(3));

            _userRepositoryMock.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>())).Returns((UserEntity)null);

            // Act
            var actual = _registerService.Execute(dto);
            var expected = BaseDtoExtension.Invalid("Telefone não pode ser nulo");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        //[Fact]
        //public void Execute_ShouldReturnInvalid_WhenOpenTimeIsInvalid()
        //{
        //    // Arrange
        //    var invalidOpenTime = DateTime.Now.AddDays(-1);
        //    var dto = new RegisterDto(20, 20, 20, "Rua B", "22", "Guarapuava", "Paraná", "Atrás do mercado", "4785489647",
        //        "ALELUIA@GMAIL.COM", "123456789-10", "Patrícia", "znpkdwor35f", "LightSaloon", invalidOpenTime, "abc.com", DateTime.Now.AddDays(20));
        //    // Act
        //    var actual = _registerService.Execute(dto);
        //    var expected = BaseDtoExtension.Invalid("Horário de abertura inválido");

        //    // Assert

        //    Assert.Equal(expected._Message, actual._Message);
        //    Assert.Equal(expected._StatusCode, actual._StatusCode);
        //}
    }
}
