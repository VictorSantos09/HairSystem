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
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly UpdateBarberService _update;
        private readonly HireBarberService _hire;
        private readonly FireBarberService _fire;

        public ManagmentWorkerService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
            _update = new(_userRepository, _barberRepository);
            _hire = new(_userRepository, _barberRepository);
            _fire = new(_barberRepository);
        }

        /// <summary>
        /// 
        /// Método que atualiza as informações de um barbeiro existente
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com as informações atualizadas do barbeiro.</param>
        /// 
        /// <returns>Retorna o resultado da operação de atualização.</returns>
        public BaseDto Update(UpdateBarberDto dto) => _update.Update(dto);

        /// <summary>
        /// 
        /// Método que contrata um novo barbeiro.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com as informações do barbeiro a ser contratado.</param>
        /// 
        /// <returns>Retorna o resultado da operação de contratação.</returns>
        public BaseDto Hire(HireBarberDto dto) => _hire.HireNewbarber(dto);

        /// <summary>
        /// 
        /// Método que demite um barbeiro existente.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com as informações do barbeiro a ser demitido.</param>
        /// 
        /// <returns>Retorna o resultado da operação de demissão.</returns>
        public BaseDto Fire(FireBarberDto dto) => _fire.FireBarber(dto);
    }
}