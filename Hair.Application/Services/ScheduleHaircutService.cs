﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Responsável pelas efetuações referentes ao agendamento de cortes
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
        /// 
        /// Efetua o agendamento do corte
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com mensagens e status code de sucesso ou falha</returns>
        public BaseDto Schedule(ScheduleHaircutDto dto)
        {

            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotNull("Usuário");

            if (dto.HaircuteTime == null)
                return BaseDtoExtension.NotNull("Horário");

            if (dto.Client.Name == null)
                return BaseDtoExtension.NotNull("Nome do cliente");

            if (dto.Client.PhoneNumber == null)
                return BaseDtoExtension.NotNull("Telefone");

            foreach (var haircut in user.Haircuts)
            {
                if (haircut.HaircuteTime == dto.HaircuteTime)
                    return BaseDtoExtension.Create(200, "Horário indisponível");
            }

            var haircuts = _haircutRepository.GetAll();

            foreach (var haircut in haircuts)
            {
                if (haircut.Client.Name == dto.Client.Name || haircut.Client.PhoneNumber == dto.Client.PhoneNumber)
                    return BaseDtoExtension.Create(406, $"Cliente {haircut.Client.Name} já agendado");
            }

            var newHaircut = new HaircutEntity(dto.UserID, dto.HaircuteTime, true, dto.Client);

            user.Haircuts.Add(newHaircut);
            _haircutRepository.Create(newHaircut);

            _userRepository.Update(user);

            return BaseDtoExtension.Sucess();
        }
    }
}