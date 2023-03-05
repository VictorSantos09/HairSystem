using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Classe para gerenciamento do funcionário, como contratar, demitir e entre outros.
    /// 
    /// </summary>
    public class ManagmentWorkerService
    {
        private readonly UpdateBarberService _update;
        private readonly HireBarberService _hire;
        private readonly FireBarberService _fire;

        public ManagmentWorkerService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository, IValidator<BarberEntity> barberValidator)
        {
            _update = new(userRepository, barberRepository,barberValidator);
            _hire = new(userRepository, barberRepository,barberValidator);
            _fire = new(barberRepository);
        }

        /// <summary>
        /// 
        /// Método que atualiza as informações de um barbeiro existente
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo UpdateBarberDto contendo as informações atualizadas do barbeiro.</param>
        /// 
        /// <returns>Objeto do tipo BaseDto com o resultado da operação de atualização.</returns>
        public BaseDto Update(UpdateBarberDto dto) => _update.Update(dto);

        /// <summary>
        /// 
        /// Método que contrata um novo barbeiro.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo HireBarberDto contendo as informações do novo barbeiro a ser contratado.</param>
        /// 
        /// <returns>Objeto do tipo BaseDto com o resultado da operação de contratação.</returns>
        public BaseDto Hire(HireBarberDto dto) => _hire.HireNewbarber(dto);

        /// <summary>
        /// 
        /// Método que demite um barbeiro existente.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo FireBarberDto contendo as informações do barbeiro a ser demitido.</param>
        /// 
        /// <returns>Objeto do tipo BaseDto com o resultado da operação de demissão.</returns>
        public BaseDto Fire(FireBarberDto dto) => _fire.FireBarber(dto);
    }
}