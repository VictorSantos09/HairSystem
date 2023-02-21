using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class VisualizeEmployeeDataService
    {
        private readonly IBaseRepository<BarberEntity> _employeeRepository;
        private readonly IGetByEmail _userRepository;

        public VisualizeEmployeeDataService(IBaseRepository<BarberEntity> employeeRepository, IGetByEmail userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public BaseDto GetEmployeeData(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return BaseDtoExtension.Invalid("Email não informado.");

            if (string.IsNullOrEmpty(password))
                return BaseDtoExtension.Invalid("Senha não informada.");

            var user = _userRepository.GetByEmail(email, password);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var employees = _employeeRepository.GetAll();

            employees.FindAll(e => e.JobSaloonId == user.Id);

            if (employees.Count == 0)
                return BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            return BaseDtoExtension.Create(200, "Relação de barbeiros.", employees);
        }
    }
}
