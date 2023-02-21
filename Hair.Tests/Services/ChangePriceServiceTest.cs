using Hair.Application.Dto;
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
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private readonly GlobalUser _globalUser;
        private ChangePriceDto _dto;

        public ChangePriceServiceTest()
        {
            _globalUser = new GlobalUser();
            _dto = new(_globalUser.Id, 20, true, true, true, true);
            _service = new ChangePriceService(_userRepositoryMock.Object);
        }

        [Fact]
        private void ChangePrice_ShouldReturn200_WhenConfirmedFalse()
        {
            _dto.Confirmed = false;

            var actual = _service.ChangeHaircutePrice(_dto);
            var expected = BaseDtoExtension.RequestCanceled();

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
        [Fact]
        private void ChangePrice_ShouldReturn406_WhenValueNegative()
        {
            _dto.NewPrice = -25;

            var actual = _service.ChangeHaircutePrice(_dto);

            var expected = BaseDtoExtension.Invalid();

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
        [Fact]
        private void ChangePrice_ShouldReturn404_WhenUserNotFounded()
        {
            var actual = _service.ChangeHaircutePrice(_dto);

            var expected = BaseDtoExtension.NotFound();

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
        [Fact]
        private void ChangePrice_ShouldReturn406_WhenAnyHaircutTrue()
        {
            var user = _globalUser.GetGlobalUser();

            _userRepositoryMock.Setup(x => x.GetById(_dto.SaloonId)).Returns(user);

            _dto.Mustache = false;
            _dto.Beard = false;
            _dto.Hair = false;

            var actual = _service.ChangeHaircutePrice(_dto);

            var expected = BaseDtoExtension.Create(406, "Escolha algum item");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
        [Fact]
        private void ChangePrice_ShouldReturn200_WhenDataIsCorrect_And_ApplyChange()
        {
            var user = _globalUser.GetGlobalUser();

            _userRepositoryMock.Setup(x => x.GetById(_dto.SaloonId)).Returns(user);

            var actual = _service.ChangeHaircutePrice(_dto);

            var expected = BaseDtoExtension.Sucess("Alteração Concluída");

            Equal(expected._Message, actual._Message);
            Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}