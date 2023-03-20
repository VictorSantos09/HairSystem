using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.ServiceOrderManagment
{
    /// <summary>
    /// 
    /// O serviço efetua a busca de todos os cortes agendados para o usuário.
    /// 
    /// </summary>
    public class ViewDutyTimeService
    {
        private readonly IBaseRepository<ServiceOrderEntity> _dutyRepository;

        /// <summary>
        /// 
        /// <param name="dutyRepository">Repositório de cortes de cabelo.</param>
        /// 
        /// </summary>
        public ViewDutyTimeService(IBaseRepository<ServiceOrderEntity> dutyRepository)
        {
            _dutyRepository = dutyRepository;
        }

        /// <summary>
        /// 
        /// Obtém os cortes de cabelo agendados por um usuário.
        /// 
        /// </summary>
        /// <param name="dto">DTO com o ID do usuário.</param>
        /// 
        /// <returns>
        /// 
        /// Objeto BaseDto com a lista de cortes de cabelo agendados.
        /// 
        /// </returns>
        public BaseDto GetScheduledHaircuts(ViewDutyTimeDto dto)
        {
            var userDuties = _dutyRepository.GetAll().FindAll(x => x.UserID == dto.UserID);

            if (userDuties.Count == 0)
            {
                return BaseDtoExtension.Create(200, "Não foram encontrados tarefas agendadas para este usuário.");
            }

            return BaseDtoExtension.Create(200, "Lista de tarefas agendados encontrados.", userDuties);
        }
    }
}
