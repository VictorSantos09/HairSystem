using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public sealed class DeleteUserServiceService : IDeleteUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServiceRepository _userServiceRepository;

        public DeleteUserServiceService(IUserRepository userRepository, IUserServiceRepository userServiceRepository)
        {
            _userRepository = userRepository;
            _userServiceRepository = userServiceRepository;
        }

        public BaseDto Delete(DeleteUserServiceDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            UserServiceEntity serviceToRemove = _userServiceRepository.GetByName(dto.ServiceName);

            if (serviceToRemove == null)
                return BaseDtoExtension.NotFound("Serviço");

            _userServiceRepository.Remove(serviceToRemove.Id);

            return BaseDtoExtension.Sucess();
        }
    }
}