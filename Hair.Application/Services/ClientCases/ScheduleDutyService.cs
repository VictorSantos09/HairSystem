using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.ClientCases;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System.Reflection;

namespace Hair.Application.Services.ClientCases
{
    /// <summary>
    /// 
    /// Responsável pelas efetuações referentes ao agendamento de cortes.
    /// 
    /// </summary>
    public class ScheduleDutyService
    {
        private readonly IApplicationDbContext<UserEntity> _userRepository;
        private readonly IApplicationDbContext<ServiceOrderEntity> _dutyRepository;
        private readonly IValidator<ServiceOrderEntity> _dutyValidator;

        public ScheduleDutyService(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<ServiceOrderEntity> dutyRepository,
            IValidator<ServiceOrderEntity> dutyValidator)
        {
            _dutyValidator = dutyValidator;
            _userRepository = userRepository;
            _dutyRepository = dutyRepository;
        }

        /// <summary>
        /// 
        /// Efetua o agendamento do serviço.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com mensagens e status code de sucesso ou falha.
        /// 
        /// </returns>
        public BaseDto Schedule(ScheduleDutyDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);
            var duties = _dutyRepository.GetAll().FindAll(x => x.UserID == dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound("Usuário");

            foreach (ServiceOrderEntity duty in duties)
            {
                if (duty.Date == dto.DutyDate)
                    return BaseDtoExtension.Create(406, "Horário indisponível");
            }

            UserServiceTypeEntity newService = new UserServiceTypeEntity();

            FunctionDataTypes dutyTypes = new FunctionDataTypes();
            Type typeDuty = duties.GetType();
            foreach (PropertyInfo pInfo in typeDuty.GetProperties())
            {
                string propertyValue = pInfo.GetValue(dutyTypes, null).ToString();

                if (dto.DutyType == propertyValue)
                {
                    newService.Name = propertyValue;
                }
            }

            var client = new ClientEntity(dto.ClientName, dto.ClientEmail, dto.ClientPhoneNumber, user.Id, new ServiceOrderEntity());
            var newDuty = new ServiceOrderEntity(dto.UserID, dto.DutyDate, client, newService);

            client.Duty = newDuty;

            var validationResult = Validation.Verify(_dutyValidator.Validate(newDuty));

            if (validationResult.Condition)
            {
                _dutyRepository.Create(newDuty);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}