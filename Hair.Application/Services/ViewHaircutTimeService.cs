using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System;

namespace Hair.Application.Services
{
    /// <summary>
    /// Serviço responsável por obter informações de horário de corte de cabelo.
    /// </summary>
    public class ViewHaircutTimeService
    {
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;
        /// <summary>
        /// <param name="haircutRepository">O repositório de cortes de cabelo.</param>
        /// </summary>
        public ViewHaircutTimeService(IBaseRepository<HaircutEntity> haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// Obtém as informações do horário de corte de cabelo para um determinado corte de cabelo.
        /// </summary>
        /// <param name="dto">As informações necessárias para obter o horário de corte de cabelo.</param>
        /// <returns>Contém informações do horário de corte de cabelo e do cliente.</returns>
        public BaseDto GetHaircutTime(ViewHaircutTimeDto dto)
        {
            var haircut = _haircutRepository.GetById(dto.HaircutId);

            if (haircut.HaircuteTime == null)
                return BaseDtoExtension.Create(406, "Não há horários de corte disponíveis.");

            if (haircut.Client == null)
                return BaseDtoExtension.Create(200, "Não foram encontrados dados de nenhum cliente.");

            if (haircut == null)
                return BaseDtoExtension.NotFound();

            object haircutData = new
            {
                haircut.Id,
                haircut.HaircuteTime,
                haircut.Client.Name,
                haircut.Client.Email,
                haircut.Client.PhoneNumber,
            };

            return BaseDtoExtension.Create(200, $"Dados do cliente: {haircut.Client} e horário do corte: {haircut.HaircuteTime}", haircutData);
        }
    }
}
