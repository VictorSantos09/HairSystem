using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class RegisterServiceTest
    {
        private Mock<IBaseRepository<UserEntity>> _repository = new();
        private RegisterService _service;

        private readonly AddressEntity _address = new("664", "3", "Blumenau", "SC", null);
        private readonly HaircutPriceEntity _haircutePrice = new(20, 20, 20);
        private readonly string _cNPJ = "55555555555555";
        private readonly string _email = "Pedro@gmail.com";
        private readonly string _phone = "47954782631";
        private readonly string _name = "Carlos";
        private readonly string _saloonName = "Carlos's";
        private readonly string _password = "Carlin";

        public RegisterServiceTest()
        {
            _service = new(_repository.Object);
        }

        [Fact]
        public void Execute_ShouldBeSucess_WhenDatasValid()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, _password, _saloonName);

            var actual = _service.Execute(dto);

            Equal(200, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenInvalidEmail()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, "pedro@.com", _cNPJ, _name, _password, _saloonName);

            var expected = BaseDtoExtension.Invalid("Email inválido");

            var actual = _service.Execute(dto);

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenInvalidSaloonName()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, _password, null);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.NotNull("Nome do salão");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenInvalidPassword()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, "", _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.Invalid("Senha muito curta");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenShortPassword()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, "uva", _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.Invalid("Senha muito curta");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenHairPriceIgualOrLessThanZero()
        {
            var price = -90;

            var dto = new RegisterDto(price, price, price, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, _password, _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.Invalid("Valor do corte de cabelo inválido");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenInvalidAddress()
        {
            var address = _address;

            address.Street = " ";
            address.City = null;

            var dto = new RegisterDto(20, 20, 20, address.Street, _address.Number, address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, _name, _password, _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.NotNull("Endereço");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenInvalidPhoneNumber()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, " ", _email, _cNPJ, _name, _password, _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.NotNull("Telefone");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenShortName()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, "Ana", _password, _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.Invalid("Nome muito curto");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Execute_ShouldntRegister_WhenNullName()
        {
            var dto = new RegisterDto(20, 20, 20, _address.Street, _address.Number, _address.City,
                _address.State, _address.Complement, _phone, _email, _cNPJ, null, _password, _saloonName);

            var actual = _service.Execute(dto);

            var expected = BaseDtoExtension.Invalid("Nome muito curto");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}