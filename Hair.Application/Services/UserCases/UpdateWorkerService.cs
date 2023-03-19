using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    /// <summary>
    /// 
    /// Define os métodos para atualização de funcionário.
    /// 
    /// </summary>
    public class UpdateWorkerService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<WorkerEntity> _workerRepository;
        private readonly IFunctionTypeRequest _functionTypeRepository;
        private readonly IValidator<WorkerEntity> _workerValidator;

        public UpdateWorkerService(IBaseRepository<UserEntity> userRepository, IBaseRepository<WorkerEntity> workerRepository,
            IValidator<WorkerEntity> workerValidator, IFunctionTypeRequest functionTypeRepository)
        {
            _userRepository = userRepository;
            _workerRepository = workerRepository;
            _workerValidator = workerValidator;
            _functionTypeRepository = functionTypeRepository;
        }

        /// <summary>
        /// 
        /// Efetua a atualização de um novo funcionário.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Dados necessários para atualizar</param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada.
        /// 
        /// </returns>
        public BaseDto Update(UpdateWorkerDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var allWorkers = _workerRepository.GetAll().FindAll(x => x.UserID == user.Id);

            if (allWorkers.Count == 0)
                return BaseDtoExtension.Create(404, "Nenhum funcionário foi encontrado");

            var workerToUpdate = allWorkers.Find(x => x.Name == dto.WorkerName || x.PhoneNumber == dto.WorkerPhoneNumber || x.Email == dto.WorkerEmail);

            if (workerToUpdate == null)
                return BaseDtoExtension.NotFound("Funcionário para atualizar");

            var function = _functionTypeRepository.GetByName(dto.NewFunction);

            if (function == null)
                return BaseDtoExtension.NotFound($"Função {dto.NewFunction}");

            var workerUpdated = new WorkerEntity(dto.NewName, dto.NewPhoneNumber, dto.NewEmail, dto.NewSalary, dto.NewAddress, dto.UserID, function);

            var validationResult = Validation.Verify(_workerValidator.Validate(workerToUpdate));

            if (validationResult.Condition)
            {
                workerToUpdate = workerUpdated;
                _workerRepository.Update(workerToUpdate);
                return BaseDtoExtension.Sucess($"Dados de {workerToUpdate.Name} atualizados");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}