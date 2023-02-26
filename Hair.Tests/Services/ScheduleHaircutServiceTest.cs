using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class ScheduleHaircutServiceTests
    {
        private readonly Mock<IBaseRepository<IUser>> _mockUserRepository;
        private readonly Mock<IBaseRepository<IHaircut>> _mockHaircutRepository;
        private readonly ScheduleHaircutService _scheduleHaircutService;

        public ScheduleHaircutServiceTests()
        {
            _mockUserRepository = new Mock<IBaseRepository<IUser>>();
            _mockHaircutRepository = new Mock<IBaseRepository<IHaircut>>();
            _scheduleHaircutService = new ScheduleHaircutService(_mockUserRepository.Object, _mockHaircutRepository.Object);
        }

        [Fact]
        public void Schedule_WhenNotConfirmed_ReturnsRequestCanceledError()
        {
            // Arrange
            var dto = new ScheduleHaircutDto(Guid.NewGuid(), null, false, null);

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
            var dto = new ScheduleHaircutDto(Guid.NewGuid(), null, true, null);

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns((UserEntity)null);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.NotNull("Usuário");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenHaircuteTimeIsNull_ReturnsNotNullError()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var dto = new ScheduleHaircutDto(user.Id, null, true, null);

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.NotNull("Horário");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenClientNameIsNull_ReturnsNotNullError()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var dto = new ScheduleHaircutDto(user.Id, "05/04/2023", true, new ClientEntity { Name = null });

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
            var dto = new ScheduleHaircutDto(user.Id, "02/04/05", true, new ClientEntity { Name = "Banana", Email = "Elefante@gmail.com", PhoneNumber = null });

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
            var haircutTime = "02/04/2004";
            var dto = new ScheduleHaircutDto(userId, haircutTime, true, new ClientEntity("Bruno", "elefante@outlook.com", "40028922"));

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(() =>
            {
                var user = new UserEntity { Id = dto.UserID };
                user.Haircuts.Add(new HaircutEntity(dto.UserID, dto.HaircuteTime, true, dto.Client));
                return user;
            });

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.Create(200, "Horário indisponível");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenClientAlreadyScheduled_ReturnsClientAlreadyScheduledError()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var haircutTime = DateTime.Today;
            var dto = new ScheduleHaircutDto(userId, haircutTime, true, new ClientEntity("Bruno", "elefante@outlook.com", "40028922"));

            var haircut = new HaircutEntity(userId, haircutTime, true, new ClientEntity("Bruno", "elefante@outlook.com", "40028922"));

            var haircuts = new List<IHaircut> { haircut };

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(new UserEntity { Id = userId });
            _mockHaircutRepository.Setup(repo => repo.GetAll()).Returns(haircuts);

            // Act
            var actual = _scheduleHaircutService.Schedule(dto);
            var expected = BaseDtoExtension.Create(406, $"Cliente {haircut.Client.Name} já agendado");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Schedule_WhenHaircutCanBeScheduled_ReturnsSuccess()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var haircutTime = "02/04/2004";
            var clientDto = new ClientEntity("Bruno", "elefante@outlook.com", "40028922");
            var dto = new ScheduleHaircutDto(userId, haircutTime, true, clientDto);

            var user = new UserEntity { Id = userId };

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            _mockHaircutRepository.Setup(repo => repo.GetAll()).Returns(new List<IHaircut>());

            _mockHaircutRepository.Setup(repo => repo.Create(It.IsAny<IHaircut>())).Callback<IHaircut>(haircut =>
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