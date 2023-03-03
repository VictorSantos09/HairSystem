using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
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
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public ScheduleHaircutService(IBaseRepository<UserEntity> userRepository, IBaseRepository<HaircutEntity> haircutRepository)
        {
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// 
        /// Efetua o agendamento do corte.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com dados do corte.</param>
        /// 
        /// <returns>Retorna o agendamento em caso de sucesso ou inválido.</returns>
        public BaseDto Schedule(ScheduleHaircutDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound("Usuário");

            if (string.IsNullOrEmpty(dto.ClientName))
                return BaseDtoExtension.NotNull("Nome do cliente");

            if (string.IsNullOrEmpty(dto.ClientPhoneNumber))
                return BaseDtoExtension.NotNull("Telefone");

            foreach (var haircut in user.Haircuts)
            {
                if (haircut.HaircuteTime == dto.HaircuteTime)
                    return BaseDtoExtension.Create(200, "Horário indisponível");
            }

            var client = new ClientEntity(dto.ClientName, dto.ClientEmail, dto.ClientPhoneNumber);
            var newHaircut = new HaircutEntity(dto.UserID, dto.HaircuteTime, true, client);

            user.Haircuts.Add(newHaircut);

            _haircutRepository.Create(newHaircut);

            return BaseDtoExtension.Sucess();
        }
    }
}