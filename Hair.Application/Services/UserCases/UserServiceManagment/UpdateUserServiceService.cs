using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    /// <summary>
    /// 
    /// Conteém a efetuação da mudança de preços do corte de cabelo, barba e bigode.
    /// 
    /// </summary>
    public sealed class UpdateUserServiceService
    {
        private readonly IApplicationDbContext<UserEntity> _userRepository;
        private readonly IApplicationDbContext<UserServiceEntity> _taskRepository;
        private readonly IApplicationDbContext<UserServiceTypeEntity> _taskTypeRepository;

        public UpdateUserServiceService(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<UserServiceEntity> taskRepository, IApplicationDbContext<UserServiceTypeEntity> taskTypeRepository)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _taskTypeRepository = taskTypeRepository;
        }

        /// <summary>
        /// 
        /// Verifica a confirmação e efetua a alteração dos valores de cortes de cabelo, barba e bigode.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada.
        /// 
        /// </returns>
        public BaseDto Update(UpdateTaskDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            UserServiceEntity? oldTask = _taskRepository.GetAll().Find(x => x.UserID == dto.UserID && x.Name == dto.OldName && x.Value == dto.OldValue);

            if (oldTask == null)
                return BaseDtoExtension.NotFound("Tarefa");

            UserServiceTypeEntity newTaskType = _taskTypeRepository.GetByName(dto.NewType);

            if (newTaskType == null)
                return BaseDtoExtension.Invalid("Tipo de tarefa inválido");

            UserServiceEntity taskUpdated = new UserServiceEntity();
            taskUpdated.Name = dto.NewName;
            taskUpdated.Value = dto.NewValue;
            taskUpdated.Type = newTaskType;
            taskUpdated.Description = dto.NewDescription;

            return BaseDtoExtension.Sucess();
        }
    }
}