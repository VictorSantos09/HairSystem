﻿using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Services.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Contém o método para efetuar a demissão de funcionários.
    /// </summary>
    public sealed class DeleteEmployeeService : IDeleteEmployee
    {
        private readonly IBaseRepository<EmployeeEntity> _employeeRepository;

        public DeleteEmployeeService(IBaseRepository<EmployeeEntity> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public BaseDto Delete(DeleteEmployeeDto dto)
        {
            var worker = _employeeRepository.GetByName(dto.WorkerName);

            if (worker == null)
                return BaseDtoExtension.NotFound("Funcionário");

            if (dto.UserID == worker.UserID && dto.WorkerName.ToUpper() == worker.Name && dto.WorkerPhoneNumber == worker.PhoneNumber)
            {
                _employeeRepository.Remove(worker.Id);

                return BaseDtoExtension.Sucess($"{worker.Name} foi desligado");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel encontrar o funcionário no salão");
        }
    }
}