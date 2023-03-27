using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    /// <summary>
    /// Contém a efetuação da mudança de preços do corte de cabelo, barba e bigode.
    /// </summary>
    public sealed class UpdateUserServiceService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServiceRepository _serviceRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public UpdateUserServiceService(IUserRepository userRepository, IUserServiceRepository serviceRepository, IServiceTypeRepository serviceTypeRepository)
        {
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _serviceTypeRepository = serviceTypeRepository;
        }

        /// <summary>
        /// Verifica a confirmação e efetua a alteração dos valores de cortes de cabelo, barba e bigode.
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada.
        /// </returns>
        public BaseDto Update(UpdateUserServiceDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            UserServiceEntity? oldService = _serviceRepository.GetAllByUserId(dto.UserID).Find(x => x.Name == dto.OldName && x.Value == dto.OldValue);

            if (oldService == null)
                return BaseDtoExtension.NotFound("Serviço");

            UserServiceTypeEntity newServiceType = _serviceTypeRepository.GetByName(dto.NewType);

            if (newServiceType == null)
                return BaseDtoExtension.Invalid("Tipo de serviço inválido");

            UserServiceEntity taskUpdated = oldService;
            taskUpdated.Name = dto.NewName;
            taskUpdated.Value = dto.NewValue;
            taskUpdated.Type = newServiceType;
            taskUpdated.Description = dto.NewDescription;

            _serviceRepository.Update(taskUpdated);

            return BaseDtoExtension.Sucess();
        }
    }
}