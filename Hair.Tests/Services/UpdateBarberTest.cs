﻿using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class UpdateBarberTest
    {
        private readonly Mock<IBaseRepository<IUser>> _userRepositoryMock = new Mock<IBaseRepository<IUser>>();
        private readonly Mock<IBaseRepository<IBarber>> _barberRepositoryMock = new Mock<IBaseRepository<IBarber>>();
        private readonly UpdateBarberService _service;
        private UpdateBarberDto _dto;
        private IBarber _barber;
        private IHaircutPrice _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private IUser _user;

        public UpdateBarberTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", new AddressEntity(),
               null, _haircutPrice, DateTime.Now, null, DateTime.Now.AddHours(4));
            _barber = new BarberEntity("Carlos", "017994578951", null, 2000, new AddressEntity(), true, _user.Id, _user.SaloonName);
            _service = new(_userRepositoryMock.Object, _barberRepositoryMock.Object);
            _dto = new(_user.Id, _barber.Name, _barber.Email, _barber.PhoneNumber, _barber.Salary, new AddressEntity(), "Carlos@gmail.com", "041991545235", "Carlos", 5000);
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
            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(new List<IBarber>());

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

            var barbers = new List<IBarber>();
            _barber.Name = "Jose";
            _barber.PhoneNumber = "047994565856";
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

        [Fact]
        public void Update_ShouldBeSucess_WhenAllOk()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.UserId)).Returns(_user);
            var barbers = new List<IBarber>();
            barbers.Add(_barber);

            _barberRepositoryMock.Setup(x => x.GetAll()).Returns(barbers);

            // Act
            var actual = _service.Update(_dto);
            var expected = BaseDtoExtension.Sucess($"Dados de {_dto.NewName} atualizados");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}