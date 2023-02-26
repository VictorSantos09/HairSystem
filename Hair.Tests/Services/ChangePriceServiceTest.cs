using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class ChangePriceServiceTest
    {
        private readonly ChangePriceService _service;
        private readonly Mock<IBaseRepository<IUser>> _userRepositoryMock = new Mock<IBaseRepository<IUser>>();
        private ChangePriceDto _dto;
        private IHaircutPrice _haircutPrice = new HaircutPriceEntity(20, 20, 20);
        private IUser _user;

        public ChangePriceServiceTest()
        {
            _user = new UserEntity("Elefante's", "victor", "047991548789", "victor@gmail.com", "Victor", new AddressEntity(), null, _haircutPrice, DateTime.Now, null, DateTime.Now.AddHours(4));
            _dto = new(_user.Id, 20, true, true, true, true);
            _service = new ChangePriceService(_userRepositoryMock.Object);
        }

        [Fact]
        private void ChangePrice_ShouldReturn200_WhenConfirmedFalse()
        {
            // Arrange
            _dto.Confirmed = false;

            // Act
            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.RequestCanceled();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        private void ChangePrice_ShouldReturn406_WhenValueNegative()
        {
            // Arrange
            _dto.NewPrice = -25;

            // Act
            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.Invalid();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        private void ChangePrice_ShouldReturn404_WhenUserNotFounded()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        private void ChangePrice_ShouldReturn406_WhenAnyHaircutTrue()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.SaloonId)).Returns(_user);
            _dto.Mustache = false;
            _dto.Beard = false;
            _dto.Hair = false;

            // Act
            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.Create(406, "Escolha algum item");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        private void ChangePrice_ShouldReturn200_WhenDataIsCorrect_And_ApplyChange()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetById(_dto.SaloonId)).Returns(_user);

            // Act
            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.Sucess("Alteração Concluída");

            // Assert
            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}