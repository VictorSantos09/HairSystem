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
        private readonly ChangeServicePriceService _service;
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private ChangeServicePriceDto _dto;
        private UserEntity _user;

       
    }
}