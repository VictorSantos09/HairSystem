﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Define os métodos para a demissão de funcionários
    /// </summary>
    public class HireBarberService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;

        public HireBarberService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// Método para contratação de novo barbeiro se confirmado true
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o salão não foi encontrado</returns>
        public BaseDto HireNewbarber(HireBarberDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var barber = new BarberEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, dto.Adress, true, user.Id, user.SaloonName);

            _barberRepository.Create(barber);

            return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
        }
    }
}