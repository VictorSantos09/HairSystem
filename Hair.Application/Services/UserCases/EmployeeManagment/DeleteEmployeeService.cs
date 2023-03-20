using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.EmployeeManagment
{
    /// <summary>
    /// 
    /// Contém o método para efetuar a demissão de funcionários.
    /// 
    /// </summary>
    public sealed class DeleteEmployeeService
    {
        private readonly IBaseRepository<EmployeeEntity> _workerRepository;

        public DeleteEmployeeService(IBaseRepository<EmployeeEntity> workerRepository)
        {
            _workerRepository = workerRepository;
        }

        /// <summary>
        /// 
        /// Método para demissão de funcionarios.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna um <see cref="BaseDto"/> Com statusCode 404,200 e 406 caso dados inválidos.
        /// 
        /// </returns>
        public BaseDto FireWorker(FireWorkerDto dto)
        {
            var worker = _workerRepository.GetByName(dto.WorkerName);

            if (worker == null)
                return BaseDtoExtension.NotFound("Funcionário");

            if (dto.UserID == worker.UserID && dto.WorkerName.ToUpper() == worker.Name && dto.WorkerPhoneNumber == worker.PhoneNumber)
            {
                _workerRepository.Remove(worker.Id);

                return BaseDtoExtension.Sucess($"{worker.Name} foi desligado");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel encontrar o funcionário no salão");
        }
    }
}