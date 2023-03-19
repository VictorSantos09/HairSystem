using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    public class ManagmentTaskService
    {
        private readonly CreateTaskService _create;
        private readonly UpdateTaskService _update;
        private readonly RemoveTaskService _remove;

        public ManagmentTaskService(IBaseRepository<UserEntity> userRepository, IBaseRepository<TaskEntity> taskRepository, 
            IBaseRepository<TaskTypeEntity> taskTypeRepository, IValidator<TaskEntity> taskValidator)
        {
            _create = new CreateTaskService(userRepository, taskRepository, taskTypeRepository, taskValidator);
            _update = new UpdateTaskService(userRepository, taskRepository, taskTypeRepository);
            _remove = new RemoveTaskService(userRepository, taskRepository);
        }

        public BaseDto Create(CreateTaskDto dto) => _create.Create(dto);
        public BaseDto Update(UpdateTaskDto dto) => _update.Update(dto);
        public BaseDto Remove(RemoveTaskDto dto) => _remove.Remove(dto);
    }
}