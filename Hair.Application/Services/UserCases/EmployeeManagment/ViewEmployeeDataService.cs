using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Define o método de buscar informações dos funcionários.
    /// </summary>
    public class ViewEmployeeDataService : IViewEmployeeData
    {
        private readonly IBaseRepository<EmployeeEntity> _employeeRepository;
        private readonly IGetByEmail _userRepository;

        public ViewEmployeeDataService(IBaseRepository<EmployeeEntity> employeeRepository, IGetByEmail userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public BaseDto GetEmployeeData(string email, string password)
        {
            if (Validation.NotEmpty(email))
                return BaseDtoExtension.Invalid("Email não informado.");

            if (Validation.NotEmpty(password))
                return BaseDtoExtension.Invalid("Senha não informada.");

            var user = _userRepository.GetByEmail(email, password);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var workers = _workerRepositories.GetAll();

            workers.FindAll(e => e.UserID == user.Id);

            if (workers.Count == 0)
                return BaseDtoExtension.Sucess("funcionários não encontrados.");

            return BaseDtoExtension.Create(200, "Relação de funcionários.", workers);
        }
    }
}
