﻿using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class DeleteAccountServiceTest
    {
        private readonly Mock<IGetByEmail> _repository = new Mock<IGetByEmail>();
        private readonly DeleteAccountService _service;
        private DeleteAccountDto _dto;
        private UserEntity _user;

        public DeleteAccountServiceTest()
        {
            _service = new(_repository.Object);
            _dto = new("Victor", "victor@gmail.com", "victor", "55555555555555", true);
            _user = new("Victor's", "Victor", "047552456897", _dto.Email, _dto.Password, null, _dto.CNPJ, null);
        }

        [Fact]
        public void Delete_ShouldntProcess_WhenUserNull()
        {
            _repository.Setup(x => x.GetByEmail(It.IsAny<string>(), It.IsAny<string>()));

            var actual = _service.Delete(_dto);

            var expected = BaseDtoExtension.NotFound();

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Delete_ShouldntProcess_WhenConfirmedFalse()
        {
            _repository.Setup(x => x.GetByEmail(_user.Email, _user.Password)).Returns(_user);

            _dto.Confirmed = false;

            var actual = _service.Delete(_dto);


            var expected = BaseDtoExtension.RequestCanceled();

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Delete_ShouldntProcess_WhenInvalidEmail()
        {
            _repository.Setup(x => x.GetByEmail(It.IsAny<string>(), _dto.Password)).Returns(_user);

            _user.Email = "victor@hotmail.com";

            var actual = _service.Delete(_dto);

            var expected = BaseDtoExtension.Invalid("Email ou senha inválidos");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Delete_ShouldntProcess_WhenInvalidPassword()
        {
            _repository.Setup(x => x.GetByEmail(_dto.Email, It.IsAny<string>())).Returns(_user);

            _user.Password = "victor123";

            var actual = _service.Delete(_dto);

            var expected = BaseDtoExtension.Invalid("Email ou senha inválidos");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Delete_ShouldProcess_WhenAllCorrect()
        {
            _repository.Setup(x => x.GetByEmail(_dto.Email, _dto.Password)).Returns(_user);

            var actual = _service.Delete(_dto);

            var expected = BaseDtoExtension.Sucess("Conta deletada com sucesso");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}
