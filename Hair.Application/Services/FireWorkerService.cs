using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Contém o método para efetuar a demissão de funcionários.
    /// 
    /// </summary>
    public class FireWorkerService
    {
        private readonly IBaseRepository<WorkerEntity> _workerRepository;

        public FireWorkerService(IBaseRepository<WorkerEntity> workerRepository)
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
        /// <returns>Retorna um <see cref="BaseDto"/> Com statusCode 404,200 e 406 caso dados inválidos.</returns>
        public BaseDto FireBarber(FireWorkerDto dto)
        {
            var barber = _workerRepository.GetById(dto.WorkerID);

            if (barber == null)
                return BaseDtoExtension.NotFound("Funcionário");

            if (dto.UserID == barber.UserID && dto.WorkerName.ToUpper() == barber.Name)
            {
                _workerRepository.Remove(barber.Id);

                return BaseDtoExtension.Sucess($"{barber.Name} foi desligado");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel encontrar o funcionário no salão");
        }
    }
}