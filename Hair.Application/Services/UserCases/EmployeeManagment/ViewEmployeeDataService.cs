using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define o método de buscar informações dos funcionários.
    /// </summary>
    public class ViewEmployeeDataService : IViewEmployeeData
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public ViewEmployeeDataService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public BaseDto GetEmployeeData(string userEmail, string userPassword)
        {
            if (Validation.NotEmpty(userEmail))
                return BaseDtoExtension.Invalid("Email não informado.");

            if (Validation.NotEmpty(userPassword))
                return BaseDtoExtension.Invalid("Senha não informada.");

            var user = _userRepository.GetByEmail(userEmail, userPassword);

            if (user == null)
                return BaseDtoExtension.NotFound();

            List<EmployeeEntity> employees = _employeeRepository.GetAllByUserId(user.Id);

            if (employees.Count == 0)
                return BaseDtoExtension.Sucess("Nenhum funcionário registrado.");

            return BaseDtoExtension.Create(200, "Relação de funcionários.", employees);
        }
    }
}
