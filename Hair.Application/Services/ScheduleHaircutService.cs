using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Responsável pelas efetuações referentes ao agendamento de cortes.
    /// 
    /// </summary>
    public class ScheduleHaircutService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<DutyEntity> _haircutRepository;
        private readonly IValidator<DutyEntity> _haircutValidator;

        public ScheduleHaircutService(IBaseRepository<UserEntity> userRepository, IBaseRepository<DutyEntity> haircutRepository,
            IValidator<DutyEntity> haircutValidator)
        {
            _haircutValidator = haircutValidator;
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// 
        /// Efetua o agendamento do corte.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagens e status code de sucesso ou falha.</returns>
        public BaseDto Schedule(ScheduleHaircutDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound("Usuário");

            foreach (var haircut in user.Haircuts)
            {
                if (haircut.Date == dto.HaircuteTime)
                    return BaseDtoExtension.Create(200, "Horário indisponível");
            }

            var client = new ClientEntity(dto.ClientName, dto.ClientEmail, dto.ClientPhoneNumber);
            var newHaircut = new DutyEntity(dto.UserID, dto.HaircuteTime, true, client);

            var validationResult = Validation.Verify(_haircutValidator.Validate(newHaircut));

            if (validationResult.Condition)
            {
                _haircutRepository.Create(newHaircut);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}