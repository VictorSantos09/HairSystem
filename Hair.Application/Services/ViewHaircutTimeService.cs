using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// O serviço efetua a busca de todos os cortes agendados para o usuário.
    /// 
    /// </summary>
    public class ViewHaircutTimeService
    {
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        /// <summary>
        /// 
        /// <param name="haircutRepository">Repositório de cortes de cabelo.</param>
        /// 
        /// </summary>
        public ViewHaircutTimeService(IBaseRepository<HaircutEntity> haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// 
        /// Obtém os cortes de cabelo agendados por um usuário.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com o ID do usuário.</param>
        /// 
        /// <returns>Retorna a lista de cortes de cabelo agendados em caso de sucesso ou inválido.</returns>
        public BaseDto GetScheduledHaircuts(ViewHaircutTimeDto dto)
        {
            var userHaircuts = _haircutRepository.GetAll().FindAll(x => x.SaloonId == dto.UserID);

            if (userHaircuts.Count == 0)
            {
                return BaseDtoExtension.Create(200, "Não foram encontrados cortes agendados para este usuário.");
            }

            return BaseDtoExtension.Create(200, "Lista de cortes agendados encontrados.", userHaircuts);
        }
    }
}
