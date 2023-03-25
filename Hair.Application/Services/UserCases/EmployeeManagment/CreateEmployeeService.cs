using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define os métodos para a contratação/criação de um novo funcionário.
    /// </summary>
    public sealed class CreateEmployeeService : ICreateEmployee
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFunctionTypeRepository _functionTypeRepository;
        private readonly IValidator<EmployeeEntity> _employeeValidator;
        private readonly IFactory _factory;

        public CreateEmployeeService(IUserRepository userRepository, IEmployeeRepository employeeRepository,
            IValidator<EmployeeEntity> employeeValidator, IFactory factory, IFunctionTypeRepository functionTypeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
            _factory = factory;
            _functionTypeRepository = functionTypeRepository;
        }

        public BaseDto Create(CreateEmployeeDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            FunctionTypeEntity? function = _functionTypeRepository.GetByName(dto.EmployeeFunction);

            if (function == null)
                return BaseDtoExtension.NotFound($" função {dto.EmployeeFunction}");

            AddressEntity emptyaddress = _factory.Address.Create();

            EmployeeEntity employee = _factory.Employee.Create(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, emptyaddress, user.Id, function);

            var address = _factory.Address.Create(dto.EmployeeStreet, dto.EmployeeHouseNumber, dto.WorkerCity, dto.WorkerState,
                dto.EmployeeHouseComplement, dto.CEP, employee.Id);

            employee.Address = address;

            ValidationResultDto validationResult = Validation.Verify(_employeeValidator.Validate(employee));

            if (validationResult.Condition)
            {
                _employeeRepository.Create(employee);
                return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}