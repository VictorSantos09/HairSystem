using Hair.Application.Common;
using Hair.Application.Dto.ClientCases;
using Hair.Application.Extensions;
using Hair.Application.Services.ClientCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Tests.Builders;
using Moq;

namespace Hair.Tests.Services
{
    public class CancelHaircutServiceTests
    {
        private CancelDutyDto _sucessDto = new CancelDutyDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", "40588626", DateTime.Now.AddDays(3));
        private readonly CancelDutyService _service;
        private readonly ServiceBuilder _serviceProvider = new ServiceBuilder();
        private readonly Mock<IApplicationDbContext<UserEntity>> _userRepositoryMock = new Mock<IApplicationDbContext<UserEntity>>();
        private readonly Mock<IApplicationDbContext<ServiceOrderEntity>> _haircutRepositoryMock = new Mock<IApplicationDbContext<ServiceOrderEntity>>();
        private readonly int _Expected = ValidationResultDto.GetStatusCode();

        public CancelHaircutServiceTests()
        {
            _service = _serviceProvider.InstanceCancelHaircutService(_userRepositoryMock, _haircutRepositoryMock);
        }


        [Fact]
        public void Cancel_When_Client_Name_Is_Invalid()
        {
            // Arrange
            UserEntity user = new UserEntity();
            user.Haircuts.Add(new ServiceOrderEntity());
            _userRepositoryMock.Setup(x => x.GetById(_sucessDto.UserID)).Returns(user);
            string? clientName = string.Empty;
            _sucessDto.ClientName = clientName;

            // Act
            var actual = _service.Cancel(_sucessDto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Cancel_When_Phone_Number_Is_Invalid()
        {
            // Arrange
            var dto = new CancelDutyDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", null, DateTime.Now.AddDays(3));

            // Act
            var actual = _service.Cancel(dto);

            // Assert
            Assert.Equal(_Expected, actual._StatusCode);
        }

        [Fact]
        public void Cancel_When_Valid_Data_Is_Passed()
        {
            // Arrange
            var validTime = DateTime.Now.AddDays(3);
            var dto = new CancelDutyDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", "47999999999", validTime);

            var user = new UserEntity
            {
                Id = dto.UserID,
                Haircuts = new List<ServiceOrderEntity>
                {
                    new ServiceOrderEntity
                    {
                       Client = new ClientEntity
                       {
                            Name = dto.ClientName,
                            PhoneNumber = dto.ClientPhoneNumber
                       },
                            Date = validTime,
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
            var dto = new CancelDutyDto(Guid.NewGuid(), false, "Carlos", "Carlos@gmail.com", "47999999999", validTime);

            var user = new UserEntity
            {
                Id = dto.UserID,
                Haircuts = new List<ServiceOrderEntity>
                {
                    new ServiceOrderEntity
                    {
                       Client = new ClientEntity
                       {
                            Name = dto.ClientName,
                            PhoneNumber = dto.ClientPhoneNumber
                       },
                            Date = DateTime.Now.AddDays(3),
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