using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System.Reflection;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// 
    /// Define os métodos para a contratação de funcionários.
    /// 
    /// </summary>
    public sealed class CreateEmployeeService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<EmployeeEntity> _workerRepository;
        private readonly IValidator<EmployeeEntity> _workerValidator;

        public CreateEmployeeService(IBaseRepository<UserEntity> userRepository, IBaseRepository<EmployeeEntity> workerRepository, IValidator<EmployeeEntity> workerValidator)
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

            Type typeFunction = functions.GetType();
            foreach (PropertyInfo pInfo in typeFunction.GetProperties())
            {
                string propertyValue = pInfo.GetValue(functions, null).ToString();

                if (dto.WorkerFunction == propertyValue)
                {
                    newFunction.Name = propertyValue;
                }
            }

            var worker = new EmployeeEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, new AddressEntity(), user.Id, newFunction);
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