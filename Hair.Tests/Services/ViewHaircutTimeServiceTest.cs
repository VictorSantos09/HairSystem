using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class ViewHaircutTimeServiceTests
    {
        private readonly ViewServiceOrderService _service;
        private readonly Mock<IApplicationDbContext<ServiceOrderEntity>> _repositoryMock;
        public ViewHaircutTimeServiceTests()
        {
            _repositoryMock = new Mock<IApplicationDbContext<ServiceOrderEntity>>();
            _service = new ViewServiceOrderService(_repositoryMock.Object);
        }

        [Fact]
        public void GetScheduledHaircuts_WithValidUserId_Returns_BaseDtoWithHaircutsList()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedHaircuts = new List<ServiceOrderEntity>
            {
                new ServiceOrderEntity { Id = Guid.NewGuid(), UserID = userId },
                new ServiceOrderEntity { Id = Guid.NewGuid(), UserID = userId}
            };

            var dto = new ViewDutyTimeDto(userId);
            _repositoryMock.Setup(x => x.GetAll()).Returns(expectedHaircuts);

            // Act
            var result = _service.GetScheduledHaircuts(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result._StatusCode);
            Assert.Equal("Lista de cortes agendados encontrados.", result._Message);
            Assert.Equal(expectedHaircuts, result._Data);
        }

        [Fact]
        public void GetScheduledHaircuts_WithInvalidUserId_Returns_BaseDtoWithErrorMessage()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedHaircuts = new List<ServiceOrderEntity>
            {
                new ServiceOrderEntity { Id = Guid.NewGuid(), UserID = Guid.NewGuid()}
            };

            var dto = new ViewDutyTimeDto(userId);
            _repositoryMock.Setup(x => x.GetAll()).Returns(expectedHaircuts);

            // Act
            var result = _service.GetScheduledHaircuts(dto);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result._StatusCode);
            Assert.Equal("Não foram encontrados cortes agendados para este usuário.", result._Message);
            Assert.Null(result._Data);
        }
    }
}