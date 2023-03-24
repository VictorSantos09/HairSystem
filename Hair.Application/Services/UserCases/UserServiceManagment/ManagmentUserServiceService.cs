using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public class ManagmentUserServiceService
    {
        private readonly CreateUserServiceService _create;
        private readonly UpdateUserServiceService _update;
        private readonly RemoveUserServiceService _remove;

        public ManagmentUserServiceService(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<UserServiceEntity> taskRepository,
            IApplicationDbContext<UserServiceTypeEntity> taskTypeRepository, IValidator<UserServiceEntity> taskValidator)
        {
            _create = new CreateUserServiceService(userRepository, taskRepository, taskTypeRepository, taskValidator);
            _update = new UpdateUserServiceService(userRepository, taskRepository, taskTypeRepository);
            _remove = new RemoveUserServiceService(userRepository, taskRepository);
        }

        public BaseDto Create(CreateUserServiceDto dto) => _create.Create(dto);
        public BaseDto Update(UpdateTaskDto dto) => _update.Update(dto);
        public BaseDto Remove(RemoveTaskDto dto) => _remove.Remove(dto);
    }
}