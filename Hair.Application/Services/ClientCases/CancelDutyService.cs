using Hair.Application.Common;
using Hair.Application.Dto.ClientCases;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.ClientCases
{
    /// <summary>
    /// 
    /// Responsável pelos métodos relacionados a cancelamento de corte.
    /// 
    /// </summary>
    public class CancelDutyService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<ServiceOrderEntity> _dutyRepository;

        public CancelDutyService(IBaseRepository<UserEntity> userRepository, IBaseRepository<ServiceOrderEntity> dutyRepository)
        {
            _userRepository = userRepository;
            _dutyRepository = dutyRepository;
        }

        /// <summary>
        /// 
        /// Efetua o cancelamento de um corte agendado existente.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna uma mensagem informando se o cancelamento foi realizado com sucesso ou se ocorreu algum erro.
        /// 
        /// </returns>
        public BaseDto Cancel(CancelDutyDto dto)
        {
            if (Validation.NotEmpty(dto.ClientName))
                return BaseDtoExtension.Invalid("Nome do cliente inválido");

            if (Validation.NotEmpty(dto.ClientPhoneNumber))
                return BaseDtoExtension.Invalid("Telefone do cliente inválido");

            if (Validation.NotEmpty(dto.DutyTime.ToString()))
                return BaseDtoExtension.Invalid("Horário do serviço inválido");

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var duty = _dutyRepository.GetAll().Find(x => x.UserID == user.Id && x.Client.Name == dto.ClientName && x.Client.PhoneNumber == dto.ClientPhoneNumber);

            if (duty == null)
                return BaseDtoExtension.NotFound("Serviços");

            _dutyRepository.Remove(duty.Id);

            return BaseDtoExtension.Sucess("tarefa cancelado com sucesso");
        }
    }
}