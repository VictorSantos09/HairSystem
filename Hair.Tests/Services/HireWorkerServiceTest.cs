﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Tests.Builders;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class HireWorkerServiceTest
    {
        private readonly int _Expected = ValidationResultDto.GetStatusCode();
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<WorkerEntity>> _barberRepositoryMock = new Mock<IBaseRepository<WorkerEntity>>();
        private readonly HireBarberService _service;
        private HireBarberDto _dto;
        private HaircutPriceEntity _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private UserEntity _user;
        private ServiceBuilder _serviceBuilder = new ServiceBuilder();
        public HireWorkerServiceTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", new AddressEntity(),
                null, _haircutPrice, TimeOnly.FromDateTime(DateTime.Now), null, TimeOnly.FromDateTime(DateTime.Now).AddHours(4));

            _service = _serviceBuilder.InstanceHireWorker(_userRepositoryMock, _barberRepositoryMock);

            _dto = new HireBarberDto("Carlos", _user.Id, "047335478456", "carlos@gmail.com", 2000, "Rua Maria Alberta", "54", "", "Blumenau", "SC", true, "458789520");
        }

        [Fact]
        public void HireNewBarber_ShouldFail_WhenUserNotFound()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.HireNewbarber(_dto);

            // Assert
            Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenConfirmedFalse()
        {
            // Arrange
            _dto.Confirmed = false;

            // Act
            var actual = _service.HireNewbarber(_dto);

            // Assert
            Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void HireNewBarber_ShouldSuccess_WhenDtoDataOk()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_user.Id)).Returns(_user);
            _barberRepositoryMock.Setup(x => x.Create(It.IsAny<WorkerEntity>()));

            // Act
            var actual = _service.HireNewbarber(_dto);
            var expected = BaseDtoExtension.Create(200, $"{_dto.Name} foi registrado");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(_Expected, actual._StatusCode);
        }
    }
}