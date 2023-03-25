using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.Repositories;
using System.Reflection;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define os métodos para a contratação de funcionários.
    /// </summary>
    public sealed class CreateEmployeeService : ICreateEmployee
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<EmployeeEntity> _employeeValidator;
        private readonly IFactory _factory;

        public CreateEmployeeService(IUserRepository userRepository, IEmployeeRepository employeeRepository,
            IValidator<EmployeeEntity> employeeValidator, IFactory factory)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
            _factory = factory;
        }

        public BaseDto Create(CreateEmployeeDto dto)
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

            var worker = _factory.Employee.Create(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, new AddressEntity(), user.Id, newFunction);
            var address = _factory.Address.Create(dto.WorkerStreet, dto.WorkerHouseNumber, dto.WorkerCity, dto.WorkerState, dto.WorkerHouseComplement, dto.CEP, worker.Id);

            worker.Address = address;

            var validationResult = Validation.Verify(_employeeValidator.Validate(worker));

            if (validationResult.Condition)
            {
                _employeeRepository.Create(worker);
                return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}