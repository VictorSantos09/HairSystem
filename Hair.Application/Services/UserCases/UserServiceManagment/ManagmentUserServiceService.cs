using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Interfaces.UserCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public class ManagmentUserServiceService
    {
        private readonly ICreateUserService _create;
        private readonly UpdateUserServiceService _update;
        private readonly IDeleteUserService _delete;

        public ManagmentUserServiceService(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<UserServiceEntity> taskRepository,
            IApplicationDbContext<UserServiceTypeEntity> taskTypeRepository, IValidator<UserServiceEntity> taskValidator)
        {
            _create = new CreateUserServiceService(userRepository, taskRepository, taskTypeRepository, taskValidator);
            _update = new UpdateUserServiceService(userRepository, taskRepository, taskTypeRepository);
            _delete = new DeleteUserServiceService(userRepository, taskRepository);
        }

        public BaseDto Create(CreateUserServiceDto dto) => _create.Create(dto);
        public BaseDto Update(UpdateUserServiceDto dto) => _update.Update(dto);
        public BaseDto Delete(DeleteUserServiceDto dto) => _delete.Delete(dto);
    }
}