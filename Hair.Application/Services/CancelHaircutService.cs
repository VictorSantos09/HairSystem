﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Responsável pelos métodos relacionados a cancelamento de corte.
    /// 
    /// </summary>
    public class CancelHaircutService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<DutyEntity> _haircutRepository;

        public CancelHaircutService(IBaseRepository<UserEntity> userRepository, IBaseRepository<DutyEntity> haircutRepository)
        {
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
        }

        /// <summary>
        /// 
        /// Efetua o cancelamento de um corte agendado existente.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns> Retorna uma mensagem informando se o cancelamento foi realizado com sucesso ou se ocorreu algum erro.</returns>
        public BaseDto Cancel(CancelHaircutDto dto)
        {
            if (Validation.NotEmpty(dto.ClientEmail))
                return BaseDtoExtension.Invalid("Nome do cliente inválido");

            if (Validation.NotEmpty(dto.ClientPhoneNumber))
                return BaseDtoExtension.Invalid("Telefone do cliente inválido");

            if (Validation.NotEmpty(dto.HaircutTime.ToString()))
                return BaseDtoExtension.Invalid("Horário de corte inválido");

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var haircut = user.Haircuts.Find(x => x.Client.Name == dto.ClientName && x.Client.PhoneNumber == dto.ClientPhoneNumber && x.Date == dto.HaircutTime);

            if (haircut == null)
                return BaseDtoExtension.NotFound("Corte");

            _haircutRepository.Remove(haircut.Id);

            return BaseDtoExtension.Sucess("Corte Cancelado com Sucesso");
        }
    }
}