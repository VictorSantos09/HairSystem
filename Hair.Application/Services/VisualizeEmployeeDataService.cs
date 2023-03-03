using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Define o método de buscar informações dos funcionários.
    /// 
    /// </summary>
    public class VisualizeEmployeeDataService
    {
        private readonly IBaseRepository<BarberEntity> _employeeRepository;
        private readonly IGetByEmail _userRepository;

        public VisualizeEmployeeDataService(IBaseRepository<BarberEntity> employeeRepository, IGetByEmail userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua a busca dos funcionários do usuário quando os paramêtros são válidos.
        /// 
        /// </summary>
        /// 
        /// <param name="email">Email do funcionário.</param>
        /// 
        /// <param name="password">Senha do funcionário.</param>
        /// 
        /// <returns>Retorna os funcionários quando encontrados ou inválido.</returns>
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

            employees.FindAll(e => e.SaloonId == user.Id);

            if (employees.Count == 0)
                return BaseDtoExtension.Sucess("Barbeiros não encontrados.");

            return BaseDtoExtension.Create(200, "Relação de barbeiros.", employees);
        }
    }
}
