using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public sealed class RemoveUserServiceService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<UserServiceEntity> _taskRepository;

        public RemoveUserServiceService(IBaseRepository<UserEntity> userRepository, IBaseRepository<UserServiceEntity> taskRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public BaseDto Remove(RemoveTaskDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            UserServiceEntity? taskToRemove = _taskRepository.GetAll().Find(x => x.UserID == dto.UserID && x.Name == dto.TaskName && x.Type.Name == dto.TaskType);

            if (taskToRemove == null)
                return BaseDtoExtension.NotFound("Tarefa");

            _taskRepository.Remove(taskToRemove.Id);

            return BaseDtoExtension.Sucess();
        }
    }
}