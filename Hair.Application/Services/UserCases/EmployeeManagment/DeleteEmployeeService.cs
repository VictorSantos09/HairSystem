using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// Contém o método para efetuar a demissão de funcionários.
    /// </summary>
    public sealed class DeleteEmployeeService : IDeleteEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public DeleteEmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public BaseDto Delete(DeleteEmployeeDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var worker = _employeeRepository.GetAllByUserId(dto.UserID).Find(x => x.Name == dto.EmployeeName && x.Id == dto.EmployeeID);

            if (worker == null)
                return BaseDtoExtension.Create(406, "Não foi possivel encontrar o funcionário no salão");

            _employeeRepository.Remove(worker.Id);

            return BaseDtoExtension.Sucess($"{worker.Name} foi desligado");

        }
    }
}