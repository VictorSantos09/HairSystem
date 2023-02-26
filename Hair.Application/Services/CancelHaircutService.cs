using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Responsável pelos métodos relacionados a cancelamento de corte
    /// </summary>
    public class CancelHaircutService
    {
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IBaseRepository<IHaircut> _haircutRepository;

        public CancelHaircutService(IBaseRepository<IUser> userRepository, IBaseRepository<IHaircut> haircutRepository)
        {
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
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

            if (string.IsNullOrEmpty(dto.ClientPhoneNumber))
                return BaseDtoExtension.Invalid("Telefone do cliente inválido");

            if (string.IsNullOrEmpty(dto.HaircutTime.ToString()))
                return BaseDtoExtension.Invalid("Horário de corte inválido");

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var haircut = user.Haircuts.Find(x => x.Client.Name == dto.ClientName && x.Client.PhoneNumber == dto.ClientPhoneNumber && x.HaircuteTime == dto.HaircutTime);

            if (haircut == null)
                return BaseDtoExtension.NotFound("Corte");

            _haircutRepository.Remove(haircut.Id);

            return BaseDtoExtension.Sucess("Corte Cancelado com Sucesso");
        }
    }
}