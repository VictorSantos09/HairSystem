using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define os métodos para atualização de funcionário.
    /// </summary>
    public sealed class UpdateEmployeeService : IUpdateEmployee
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFunctionTypeRepository _functionTypeRepository;
        private readonly IValidator<EmployeeEntity> _employeeValidator;

        public UpdateEmployeeService(IUserRepository userRepository, IEmployeeRepository employeeRepository,
            IFunctionTypeRepository functionTypeRepository, IValidator<EmployeeEntity> employeeValidator)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _functionTypeRepository = functionTypeRepository;
            _employeeValidator = employeeValidator;
        }

        public BaseDto Update(UpdateEmployeeDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            List<EmployeeEntity> employees = _employeeRepository.GetAllByUserId(dto.UserID);

            if (employees.Count == 0)
                return BaseDtoExtension.Create(404, "Nenhum funcionário foi encontrado");

            var employeeToUpdate = employees.Find(x => x.Name == dto.WorkerName && x.Email == dto.WorkerEmail && x.PhoneNumber == dto.WorkerPhoneNumber);

            if (employeeToUpdate == null)
                return BaseDtoExtension.NotFound("Funcionário para atualizar");

            FunctionTypeEntity function = _functionTypeRepository.GetByName(dto.NewFunction);

            if (function == null)
                return BaseDtoExtension.NotFound($"Função {dto.NewFunction}");

            var workerUpdated = new EmployeeEntity(dto.NewName, dto.NewPhoneNumber, dto.NewEmail, dto.NewSalary, dto.NewAddress, dto.UserID, function); // aplicar autoMapper

            ValidationResultDto validationResult = Validation.Verify(_employeeValidator.Validate(employeeToUpdate));

            if (validationResult.Condition)
            {
                employeeToUpdate = workerUpdated;
                _employeeRepository.Update(employeeToUpdate);
                return BaseDtoExtension.Sucess($"Dados de {employeeToUpdate.Name} atualizados");
            }

            return Validation.ToBaseDto(validationResult);

        }
    }
}