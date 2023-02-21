using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hair.Application.Services
{
    public class VisualizeEmployeeDataService
    {
        private readonly IBaseRepository<BarberEntity> _employeeRepository;
        private readonly IGetByEmail _userRepository;

        public VisualizeEmployeeDataService(IBaseRepository<BarberEntity> employeeRepository, IGetByEmail userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public BaseDto GetEmployeeData(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return BaseDtoExtension.Invalid("Email não informado.");

            if (string.IsNullOrEmpty(password))
                return BaseDtoExtension.Invalid("Senha não informada.");

            var user = _userRepository.GetByEmail(email, password);

            if (user == null)
                return BaseDtoExtension.NotFound("Usuário não encontrado.");

            var employees = _employeeRepository.GetAll().Where(e => e.JobSaloonId == user.Id).ToList();

            if (!employees.Any())
                return BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            return BaseDtoExtension.Create(200, "Relação de barbeiros.", employees);
        }
    }
}