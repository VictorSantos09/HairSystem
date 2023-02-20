using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Application.Services
{
    public class VisualizeEmployeeDataService 
    {
        private readonly IBaseRepository<BarberEntity> _employeeData;
        private readonly IGetByEmail _userRepository;

        public VisualizeEmployeeDataService(IBaseRepository<BarberEntity> employeeData)
        {
            _employeeData = employeeData;
        }

        public BaseDto GetEmployeeData(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return BaseDtoExtension.Invalid("Email não informado.");

            if (string.IsNullOrEmpty(password))
                return BaseDtoExtension.Invalid("Senha não informada.");

            var user = _userRepository.GetByEmail(email, password);

            if (user == null)
                return BaseDtoExtension.NotFound("Usuários não encontrados.");

            var employees = _employeeData.GetAll().FindAll(e => e.JobSaloonId == user.Id);

            if (employees.Count <= 0)
                return BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            return BaseDtoExtension.Create(200, "Relação de barbeiros.", employees);
        }
    }
}
    