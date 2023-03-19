using Hair.Application.Common;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    /// <summary>
    /// 
    /// Define o método de buscar informações dos funcionários.
    /// 
    /// </summary>
    public class ViewWorkerDataService
    {
        private readonly IBaseRepository<WorkerEntity> _workerRepositories;
        private readonly IGetByEmail _userRepository;

        public ViewWorkerDataService(IBaseRepository<WorkerEntity> workerRepository, IGetByEmail userRepository)
        {
            _workerRepositories = workerRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua a busca dos funcionários do usuário quando paramêtros fornecidos válidos.
        /// 
        /// </summary>
        /// 
        /// <param name="email"></param>
        /// 
        /// <param name="password"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com Data sendo os funcionários quando encontrado, também retornando status code e mensagem.
        /// 
        /// </returns>
        public BaseDto GetWorkerData(string email, string password)
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
