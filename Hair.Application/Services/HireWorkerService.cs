﻿using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System.Reflection;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Define os métodos para a contratação de funcionários.
    /// 
    /// </summary>
    public class HireWorkerService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<WorkerEntity> _workerRepository;
        private readonly IValidator<WorkerEntity> _workerValidator;

        public HireWorkerService(IBaseRepository<UserEntity> userRepository, IBaseRepository<WorkerEntity> workerRepository, IValidator<WorkerEntity> workerValidator)
        {
            _userRepository = userRepository;
            _workerRepository = workerRepository;
            _workerValidator = workerValidator;
        }


        /// <summary>
        /// 
        /// Método para contratação de novo funcionário se confirmado <see langword="true"/>.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o usuário não foi encontrado.</returns>
        public BaseDto HireNewWorker(HireWorkerDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            
            FunctionTypeEntity newFunction = new FunctionTypeEntity();
            
            FunctionDataTypes functions = new FunctionDataTypes();
            Type typeFunction = functions.GetType();
            foreach (PropertyInfo pInfo in typeFunction.GetProperties())
            {
                string propertyValue = pInfo.GetValue(functions, null).ToString();

                if(dto.WorkerFunction == propertyValue)
                {
                    newFunction.Name = propertyValue;
                }
            }

            var worker = new WorkerEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, new AddressEntity(), user.Id, newFunction);
            var address = new AddressEntity(dto.WorkerStreet, dto.WorkerHouseNumber, dto.WorkerCity, dto.WorkerState, dto.WorkerHouseComplement, dto.CEP, worker.Id);

            worker.Address = address;

            var validationResult = Validation.Verify(_workerValidator.Validate(worker));

            if (validationResult.Condition)
            {
                _workerRepository.Create(worker);
                return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}