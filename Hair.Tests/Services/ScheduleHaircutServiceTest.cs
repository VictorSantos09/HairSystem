﻿using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class ScheduleHaircutServiceTests
    {
        private readonly Mock<IBaseRepository<UserEntity>> _mockUserRepository;
        private readonly Mock<IBaseRepository<DutyEntity>> _mockHaircutRepository;
        private readonly ScheduleDutyService _scheduleHaircutService;

        public ScheduleHaircutServiceTests()
        {
            _mockUserRepository = new Mock<IBaseRepository<UserEntity>>();
            _mockHaircutRepository = new Mock<IBaseRepository<DutyEntity>>();
            _scheduleHaircutService = new ScheduleDutyService(_mockUserRepository.Object, _mockHaircutRepository.Object, null);
        }

        [Fact]
        public void Schedule_WhenNotConfirmed_ReturnsRequestCanceledError()
        {
            // Arrange
            var dto = new ScheduleHaircutDto(Guid.NewGuid(), DateTime.Today.AddDays(1), false, null, null, null);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.RequestCanceled();

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenUserIsNull_ReturnsNotNullError()
        {
            // Arrange
            var dto = new ScheduleHaircutDto(Guid.NewGuid(), DateTime.Today.AddDays(1), true, "3009494", "banana@gmail.com", "Erin");

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns((UserEntity?)null);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.NotFound("Usuário");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenHaircuteTimeIsNull_ReturnsNotNullError()
        {
            // Arrange
            var mockPrice = new HaircutPriceEntity(20, 20, 20);

            var user = new UserEntity("CarlinHair", "Carlos", "400282738", "carlin@hotmail.com", "guaranajesus", new AddressEntity(), null, 
                mockPrice, TimeOnly.FromDateTime(DateTime.Now), null, TimeOnly.FromDateTime(DateTime.Now).AddHours(4));
            DateTime? haircutTime = null;

            var mockAdress = new AddressEntity("Rua das Palmeiras", "666", "Blumenau", "Santa Catarina", "Perto do terminal", "45213580",user.Id);

            user.Address = mockAdress;

            var scheduledTime = haircutTime.HasValue ? (DateTime)haircutTime : DateTime.Now.AddDays(1);

            var expected = BaseDtoExtension.NotNull("Horário do corte de cabelo não pode ser nulo");

            // Act
            var dto = new ScheduleHaircutDto(user.Id, scheduledTime, true, "40028922", "exu@gmail.com", "Bruno");
            var actual = _scheduleHaircutService.Schedule(dto);

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }


        [Fact]
        public void Schedule_WhenClientNameIsNull_ReturnsNotNullError()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var dto = new ScheduleHaircutDto(user.Id, DateTime.Today.AddDays(1), true, "40028922", "elefante@gmail.com", null);

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.NotNull("Nome do cliente");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);

        }

        [Fact]
        public void Schedule_WhenClientPhoneNumberIsNull_ReturnsNotNullError()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var dto = new ScheduleHaircutDto(user.Id, DateTime.Today.AddDays(1), true, null, "Elefante@gmail.com", "Arroz");

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.NotNull("Telefone");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenHaircutTimeIsUnavailable_ReturnsUnavailableError()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dto = new ScheduleHaircutDto(userId, DateTime.Today.AddDays(1), true, "Bruno", "elefante@outlook.com", "40028922");

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(() =>
            {
                var client = new ClientEntity { Name = "Bruno", Email = "elefante@gmail.com", PhoneNumber = "992839" };
                var user = new UserEntity { Id = dto.UserID };
                user.Haircuts.Add(new DutyEntity(dto.UserID, dto.HaircuteTime, true, client));
                return user;
            });

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.Create(200, "Horário indisponível");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
        public void Schedule_WhenHaircutCanBeScheduled_ReturnsSuccess()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dto = new ScheduleHaircutDto(userId, DateTime.Today.AddDays(1), true, "44029392", "abc@outlook.com", "André");

            var user = new UserEntity { Id = userId };

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            _mockHaircutRepository.Setup(repo => repo.GetAll()).Returns(new List<DutyEntity>());

            _mockHaircutRepository.Setup(repo => repo.Create(It.IsAny<DutyEntity>())).Callback<DutyEntity>(haircut =>
            {
                user.Haircuts.Add(haircut);
            });

            _mockUserRepository.Setup(repo => repo.Update(It.IsAny<UserEntity>())).Callback<UserEntity>(updatedUser =>
            {
                user = updatedUser;
            });

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.Sucess();

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}