using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define os métodos para atualização de funcionário.
    /// </summary>
    public sealed class UpdateEmployeeService : IUpdateEmployee
    {
        private readonly IApplicationDbContext<UserEntity> _userRepository;
        private readonly IApplicationDbContext<EmployeeEntity> _employeeRepository;
        private readonly IFunctionTypeRequestDbContext _functionTypeRepository;
        private readonly IValidator<EmployeeEntity> _employeeValidator;

        public UpdateEmployeeService(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<EmployeeEntity> employeeRepository,
            IFunctionTypeRequestDbContext functionTypeRepository, IValidator<EmployeeEntity> employeeValidator)
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

            var allWorkers = _employeeRepository.GetAll().FindAll(x => x.UserID == user.Id);

            if (allWorkers.Count == 0)
                return BaseDtoExtension.Create(404, "Nenhum funcionário foi encontrado");

            var workerToUpdate = allWorkers.Find(x => x.Name == dto.WorkerName || x.PhoneNumber == dto.WorkerPhoneNumber || x.Email == dto.WorkerEmail);

            if (workerToUpdate == null)
                return BaseDtoExtension.NotFound("Funcionário para atualizar");

            var function = _functionTypeRepository.GetByName(dto.NewFunction);

            if (function == null)
                return BaseDtoExtension.NotFound($"Função {dto.NewFunction}");

            var workerUpdated = new EmployeeEntity(dto.NewName, dto.NewPhoneNumber, dto.NewEmail, dto.NewSalary, dto.NewAddress, dto.UserID, function);

            var validationResult = Validation.Verify(_employeeValidator.Validate(workerToUpdate));

            if (validationResult.Condition)
            {
                workerToUpdate = workerUpdated;
                _employeeRepository.Update(workerToUpdate);
                return BaseDtoExtension.Sucess($"Dados de {workerToUpdate.Name} atualizados");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}