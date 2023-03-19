using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    public sealed class CreateTaskService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<TaskEntity> _taskRepository;
        private readonly IBaseRepository<TaskTypeEntity> _taskTypeRepository;
        private readonly IValidator<TaskEntity> _taskValidator;

        public CreateTaskService(IBaseRepository<UserEntity> userRepository, IBaseRepository<TaskEntity> taskRepository, 
            IBaseRepository<TaskTypeEntity> taskTypeRepository, IValidator<TaskEntity> taskValidator)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _taskTypeRepository = taskTypeRepository;
            _taskValidator = taskValidator;
        }

        public BaseDto Create(CreateTaskDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            TaskTypeEntity taskType = _taskTypeRepository.GetByName(dto.TaskType);

            if (taskType == null)
                return BaseDtoExtension.Invalid("Tipo de tarefa inválido");

            var userTasks = _taskRepository.GetAll().FindAll(x => x.UserID == user.Id);

            if (userTasks.Exists(x => x.Name == dto.Name && x.Type.Name == dto.TaskType))
                return BaseDtoExtension.Invalid("Não é possível criar tarefas iguais");

            TaskEntity task = new TaskEntity(user.Id, dto.Name, dto.Value, dto.Description, taskType);

            ValidationResultDto result = Validation.Verify(_taskValidator.Validate(task));

            if (result.Condition)
            {
                _taskRepository.Create(task);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(result);
        }
    }
}