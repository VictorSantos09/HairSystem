using Hair.Application.Extensions;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class ChangePriceServiceTest
    {
        private readonly ChangePriceService _service;
        private readonly Mock<IBaseRepository<UserEntity>> _RepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private double _newPrice = 20;
        private readonly GlobalUser _globalUser;

        public ChangePriceServiceTest()
        {
            _globalUser = new GlobalUser();
            _service = new ChangePriceService(_RepositoryMock.Object);
        }

        [Fact]
        private void ChangePrice_ShouldReturn200_WhenConfirmedFalse()
        {
            var actual = _service.ChangeHaircutePrice(_newPrice, It.IsAny<Guid>(), false, true, false, false);
            var expected = BaseDtoExtension.RequestCanceled();

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
            Equal(expected._Data, actual._Data);
        }
        [Fact]
        private void ChangePrice_ShouldReturn406_WhenValueNegative()
        {
            var newPrice = -25;
            var expected = BaseDtoExtension.ValueNotAllowed();

            var actual = _service.ChangeHaircutePrice(newPrice, It.IsAny<Guid>(), true, true, false, false);

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
            Equal(expected._Data, actual._Data);
        }
        [Fact]
        private void ChangePrice_ShouldReturn404_WhenUserNotFounded()
        {
            var expected = UserMessageExtension.UserNotFound();

            var actual = _service.ChangeHaircutePrice(_newPrice, It.IsAny<Guid>(), true, true, false, false);

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
            Equal(expected._Data, actual._Data);
        }
        [Fact]
        private void ChangePrice_ShouldReturn406_WhenNotCorrectHaircute()
        {
            var userEntity = _globalUser.GetGlobalUser();

            _RepositoryMock.Setup(x => x.Create(userEntity));
            _RepositoryMock.Setup(x => x.GetById(userEntity.Id)).Returns(_globalUser.GetGlobalUser());

            var actual = _service.ChangeHaircutePrice(_newPrice, userEntity.Id, true, false, false, false);

            var expected = BaseDtoExtension.Create(406, "Escolha algum item");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
            Equal(expected._Data, actual._Data);
        }
        [Fact]
        private void ChangePrice_ShouldReturn200_WhenDataIsCorrect_And_ApplyChange()
        {
            var globalUser = _globalUser.GetGlobalUser();

            _RepositoryMock.Setup(x => x.Create(globalUser));
            _RepositoryMock.Setup(x => x.GetById(globalUser.Id)).Returns(globalUser);

            var actual = _service.ChangeHaircutePrice(_newPrice, globalUser.Id, true, true, true, true);

            var expected = BaseDtoExtension.Sucessfull("Alteração Concluída");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
            Equal(expected._Data, actual._Data);
        }
    }
}