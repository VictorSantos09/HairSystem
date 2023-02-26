using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Classe para gerenciamento do Funcionário, como contratar, demitir entre outros
    /// </summary>
    public class ManagmentWorkerService
    {
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IBaseRepository<IBarber> _barberRepository;
        private readonly UpdateBarberService _update;
        private readonly HireBarberService _hire;
        private readonly FireBarberService _fire;

        public ManagmentWorkerService(IBaseRepository<IUser> userRepository, IBaseRepository<IBarber> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
            _update = new(_userRepository, _barberRepository);
            _hire = new(_userRepository, _barberRepository);
            _fire = new(_barberRepository);
        }

        public BaseDto Update(UpdateBarberDto dto) => _update.Update(dto);
        public BaseDto Hire(HireBarberDto dto) => _hire.HireNewbarber(dto);
        public BaseDto Fire(FireBarberDto dto) => _fire.FireBarber(dto);
    }
}