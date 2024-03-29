﻿using Hair.Application.Common;
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
        private readonly IBaseRepository<DutyEntity> _haircutRepository;

        /// <summary>
        /// 
        /// <param name="haircutRepository">Repositório de cortes de cabelo.</param>
        /// 
        /// </summary>
        public ViewHaircutTimeService(IBaseRepository<DutyEntity> haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// 
        /// Obtém os cortes de cabelo agendados por um usuário.
        /// 
        /// </summary>
        /// <param name="dto">DTO com o ID do usuário.</param>
        /// 
        /// <returns>Objeto BaseDto com a lista de cortes de cabelo agendados.</returns>
        public BaseDto GetScheduledHaircuts(ViewHaircutTimeDto dto)
        {
            var userHaircuts = _haircutRepository.GetAll().FindAll(x => x.UserID == dto.UserID);

            if (userHaircuts.Count == 0)
            {
                return BaseDtoExtension.Create(200, "Não foram encontrados cortes agendados para este usuário.");
            }

            return BaseDtoExtension.Create(200, "Lista de cortes agendados encontrados.", userHaircuts);
        }
    }
}
