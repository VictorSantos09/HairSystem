using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Define os métodos para a demissão de funcionários
    /// </summary>
    public class HireBarberService
    {
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IBaseRepository<IBarber> _barberRepository;

        public HireBarberService(IBaseRepository<IUser> userRepository, IBaseRepository<IBarber> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// Método para contratação de novo barbeiro se confirmado true
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o salão não foi encontrado</returns>
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
