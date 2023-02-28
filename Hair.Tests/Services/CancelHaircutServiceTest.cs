using System;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using Xunit;

namespace Hair.Tests.Application.Services
{
    public class CancelHaircutServiceTests
    {
        private readonly CancelHaircutService _service;
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock;
        private readonly Mock<IBaseRepository<HaircutEntity>> _haircutRepositoryMock;

        public CancelHaircutServiceTests()
        {
            _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
            _haircutRepositoryMock = new Mock<IBaseRepository<HaircutEntity>>();

            _service = new CancelHaircutService(_userRepositoryMock.Object, _haircutRepositoryMock.Object);
        }


        [Fact]
        public void Cancel_When_Client_Name_Is_Invalid()
        {
            // Arrange
            string? clientName = string.Empty;
            var dto = new CancelHaircutDto(Guid.NewGuid(), false, clientName, "Carlos@gmail.com", "40588626", DateTime.Now.AddDays(3));

            // Act
            var actual = _service.Cancel(dto);
            var expected = BaseDtoExtension.Invalid("Nome do cliente inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Cancel_When_Phone_Number_Is_Invalid()
        {
            // Arrange
            var dto = new CancelHaircutDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", null, DateTime.Now.AddDays(3));

            // Act
            var actual = _service.Cancel(dto);
            var expected = BaseDtoExtension.Invalid("Telefone do cliente inválido");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Cancel_When_Valid_Data_Is_Passed()
        {
            // Arrange
            var validTime = DateTime.Now.AddDays(3);
            var dto = new CancelHaircutDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", "47999999999", validTime);

            var user = new UserEntity
            {
                Id = dto.UserID,
                Haircuts = new List<HaircutEntity>
                {
                    new HaircutEntity
                    {
                       Client = new ClientEntity
                       {
                            Name = dto.ClientName,
                            PhoneNumber = dto.ClientPhoneNumber
                       },
                            HaircuteTime = validTime,
                    }   
                }
            };

            _userRepositoryMock.Setup(x => x.GetById(dto.UserID)).Returns(user);
            // Act
            var actual = _service.Cancel(dto);
            var expected = BaseDtoExtension.Sucess("Corte Cancelado com Sucesso");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Cancel_When_Valid_Not_Found_Haircut()
        {
            // Arrange
            var validTime = DateTime.Now.AddDays(3);
            var dto = new CancelHaircutDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", "47999999999", validTime);

            var user = new UserEntity
            {
                Id = dto.UserID,
                Haircuts = new List<HaircutEntity>
                {
                    new HaircutEntity
                    {
                       Client = new ClientEntity
                       {
                            Name = dto.ClientName,
                            PhoneNumber = dto.ClientPhoneNumber
                       },
                            HaircuteTime = DateTime.Now.AddDays(3),
                    }
                }
            };

            _userRepositoryMock.Setup(x => x.GetById(dto.UserID)).Returns(user);
            // Act
            var actual = _service.Cancel(dto);
            var expected = BaseDtoExtension.NotFound("Corte");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}