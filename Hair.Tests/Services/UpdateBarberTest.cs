﻿using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class UpdateBarberTest
    {
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepositoryMock = new Mock<IBaseRepository<BarberEntity>>();
        private readonly UpdateBarberService _service;
        private readonly GlobalUser _globalUser = new();
        private UpdateBarberDto _dto;
        private UserEntity _user;
        private BarberEntity _barber;

        public UpdateBarberTest()
        {
            _service = new(_userRepositoryMock.Object, _barberRepositoryMock.Object);
            _user = _globalUser.GetGlobalUser();
            _barber = _globalUser.GetBarber();
            _dto = new(_user.Id, _barber.Name, _barber.Email, _barber.PhoneNumber, _barber.Salary, _globalUser.GetAdress(), "Carlos@gmail.com", "041991545235", "Carlos", 5000);
        }

        [Fact]
        public void Update_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Update_ShouldFail_WhenAnyBarberFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserId)).Returns(_user);
            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(new List<BarberEntity>());

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.Create(404, "Nenhum barbeiro foi encontrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Update_ShouldFail_WhenNoneBarberToUpdateFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserId)).Returns(_user);

            var barbers = new List<BarberEntity>();
            _barber.Name = "Jose";
            _dto.BarberName = "Maria";
            barbers.Add(_barber);

            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(barbers);

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.NotFound("Barbeiro para atualizar");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}