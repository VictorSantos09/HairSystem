using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// 
    /// Classe para gerenciamento do funcionário, como contratar, demitir e entre outros.
    /// 
    /// </summary>
    public class EmployeeManagmentService
    {
        private readonly UpdateEmployeeService _update;
        private readonly CreateEmployeeService _hire;
        private readonly DeleteEmployeeService _fire;

        public EmployeeManagmentService(IBaseRepository<UserEntity> userRepository, IBaseRepository<WorkerEntity> workerRepository,
            IValidator<WorkerEntity> workerValidator, IFunctionTypeRequest functionTypeRepository)
        {
            _update = new(userRepository, workerRepository, workerValidator, functionTypeRepository);
            _hire = new(userRepository, workerRepository, workerValidator);
            _fire = new(workerRepository);
        }

        /// <summary>
        /// 
        /// Método que atualiza as informações de um funcionário existente
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo UpdateWorkerDto contendo as informações atualizadas do funcionário.</param>
        /// 
        /// <returns>
        /// 
        /// Objeto do tipo BaseDto com o resultado da operação de atualização.
        /// 
        /// </returns>
        public BaseDto Update(UpdateWorkerDto dto) => _update.Update(dto);

        /// <summary>
        /// 
        /// Método que contrata um novo funcionário.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo HireWorkerDto contendo as informações do novo funcionário a ser contratado.</param>
        /// 
        /// <returns>
        /// 
        /// Objeto do tipo BaseDto com o resultado da operação de contratação.
        /// 
        /// </returns>
        public BaseDto Hire(HireWorkerDto dto) => _hire.HireNewWorker(dto);

        /// <summary>
        /// 
        /// Método que demite um funcionário existente.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo FireWorkerDto contendo as informações do funcionário a ser demitido.</param>
        /// 
        /// <returns>
        /// 
        /// Objeto do tipo BaseDto com o resultado da operação de demissão.
        /// 
        /// </returns>
        public BaseDto Fire(FireWorkerDto dto) => _fire.FireWorker(dto);
    }
}