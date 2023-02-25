using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Responsável pelos métodos relacionados a cancelamento de corte
    /// </summary>
    public class CancelHaircutService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public CancelHaircutService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Efetua o cancelamento de um corte agendado existente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseDto Cancel(CancelHaircutDto dto)
        {
            if (string.IsNullOrEmpty(dto.ClientName))
                return BaseDtoExtension.Invalid("Nome do cliente inválido");
            
            if(string.IsNullOrEmpty(dto.ClientPhoneNumber))
                return BaseDtoExtension.Invalid("Telefone do cliente inválido");

            if(string.IsNullOrEmpty(dto.HaircutTime.ToString()))
                return BaseDtoExtension.Invalid("Horário de corte inválido");

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

           var haircut = user.Haircuts.Find(x => x.Client.Name == dto.ClientName && x.Client.PhoneNumber == dto.ClientPhoneNumber && x.HaircuteTime == dto.HaircutTime);

            if (haircut == null)
                return BaseDtoExtension.NotFound("Corte");

            user.Haircuts.Remove(haircut);

            _userRepository.Update(user);

            return BaseDtoExtension.Sucess("Corte Cancelado com Sucesso");
        }
    }
}