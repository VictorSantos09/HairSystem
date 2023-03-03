using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Define os métodos para a contratação de funcionários.
    /// 
    /// </summary>
    public class HireBarberService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;

        public HireBarberService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// 
        /// Método para contratação de novo barbeiro se confirmado <see langword="true"/>.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto que contém dados do funcionário a ser contratado.</param>
        /// 
        /// <returns>Retorna a contratação em caso de sucesso ou inválido.</returns>
        public BaseDto HireNewbarber(HireBarberDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var address = new AddressEntity(dto.BarberStreet, dto.BarberHouseNumber, dto.BarberCity, dto.BarberState, dto.BarberHouseComplement);
            var barber = new BarberEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, address, true, user.Id, user.SaloonName);

            _barberRepository.Create(barber);

            return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
        }
    }
}
