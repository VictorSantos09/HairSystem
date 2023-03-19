using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System.Reflection;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Responsável pelas efetuações referentes ao agendamento de cortes.
    /// 
    /// </summary>
    public class ScheduleDutyService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<DutyEntity> _dutyRepository;
        private readonly IValidator<DutyEntity> _dutyValidator;

        public ScheduleDutyService(IBaseRepository<UserEntity> userRepository, IBaseRepository<DutyEntity> dutyRepository,
            IValidator<DutyEntity> dutyValidator)
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

            foreach (DutyEntity duty in duties)
            {
                if (duty.Date == dto.DutyDate)
                    return BaseDtoExtension.Create(406, "Horário indisponível");
            }

            ServiceTypeEntity newService = new ServiceTypeEntity();

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

            var client = new ClientEntity(dto.ClientName, dto.ClientEmail, dto.ClientPhoneNumber, user.Id, new DutyEntity());
            var newDuty = new DutyEntity(dto.UserID, dto.DutyDate, client, newService);

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