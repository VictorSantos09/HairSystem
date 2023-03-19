using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    public sealed class RemoveTaskService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<TaskEntity> _taskRepository;

        public RemoveTaskService(IBaseRepository<UserEntity> userRepository, IBaseRepository<TaskEntity> taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public BaseDto Remove(RemoveTaskDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            TaskEntity? taskToRemove = _taskRepository.GetAll().Find(x => x.UserID == dto.UserID && x.Name == dto.TaskName && x.Type.Name == dto.TaskType);

            if (taskToRemove == null) 
                return BaseDtoExtension.NotFound("Tarefa");

            _taskRepository.Remove(taskToRemove.Id);

            return BaseDtoExtension.Sucess();
        }
    }
}