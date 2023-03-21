using Hair.Application.Dto.UserCases;
using Hair.Application.Services.UserCases.UserServiceManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class ChangePriceServiceTest
    {
        private readonly UpdateUserServiceService _service;
        private readonly Mock<IBaseRepository<UserEntity>> _userRepositoryMock = new Mock<IBaseRepository<UserEntity>>();
        private UpdateTaskDto _dto;
        private UserEntity _user;


    }
}