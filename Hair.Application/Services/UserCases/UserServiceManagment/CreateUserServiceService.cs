using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public sealed class CreateUserServiceService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<UserServiceEntity> _userServiceRepository;
        private readonly IBaseRepository<UserServiceTypeEntity> _userServiceTypeRepository;
        private readonly IValidator<UserServiceEntity> _userServiceValidator;

        public CreateUserServiceService(IBaseRepository<UserEntity> userRepository, IBaseRepository<UserServiceEntity> userServiceRepository,
            IBaseRepository<UserServiceTypeEntity> userServiceTypeRepository, IValidator<UserServiceEntity> userServiceValidator)
        {
            _userRepository = userRepository;
            _userServiceRepository = userServiceRepository;
            _userServiceTypeRepository = userServiceTypeRepository;
            _userServiceValidator = userServiceValidator;
        }

        public BaseDto Create(CreateUserServiceDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            UserServiceTypeEntity taskType = _userServiceTypeRepository.GetByName(dto.TaskType);

            if (taskType == null)
                return BaseDtoExtension.Invalid("Tipo de tarefa inválido");

            var userTasks = _userServiceRepository.GetAll().FindAll(x => x.UserID == user.Id);

            if (userTasks.Exists(x => x.Name == dto.Name && x.Type.Name == dto.TaskType))
                return BaseDtoExtension.Invalid("Não é possível criar tarefas iguais");

            UserServiceEntity task = new UserServiceEntity(user.Id, dto.Name, dto.Value, dto.Description, taskType);

            ValidationResultDto result = Validation.Verify(_userServiceValidator.Validate(task));

            if (result.Condition)
            {
                _userServiceRepository.Create(task);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(result);
        }
    }
}