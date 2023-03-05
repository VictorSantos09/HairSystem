using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
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
        private readonly IValidator<BarberEntity> _barberValidator;

        public HireBarberService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository, IValidator<BarberEntity> barberValidator)
        {
            _barberValidator = barberValidator;
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// 
        /// Método para contratação de novo barbeiro se confirmado <see langword="true"/>.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o salão não foi encontrado.</returns>
        public BaseDto HireNewbarber(HireBarberDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var address = new AddressEntity(dto.BarberStreet, dto.BarberHouseNumber, dto.BarberCity, dto.BarberState, dto.BarberHouseComplement, dto.CEP);
            var barber = new BarberEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, address, true, user.Id, user.SaloonName);

            var validationResult = Validation.Verify(_barberValidator.Validate(barber));

            if (validationResult.Condition)
            {
                _barberRepository.Create(barber);
                return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}
