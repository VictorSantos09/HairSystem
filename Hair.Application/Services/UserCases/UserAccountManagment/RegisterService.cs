using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserAccountManagment
{
    /// <summary>
    /// Classe responsável por executar o cadastro.
    /// </summary>
    public class RegisterService : IRegister
    {
        private readonly IGetByEmailDbContext _userRepository;
        private readonly IValidator<UserEntity> _userValidator;
        private readonly IFactory _factory;

        public RegisterService(IGetByEmailDbContext userRepository, IValidator<UserEntity> userValidator, IFactory factory)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _factory = factory;
        }

        public BaseDto Register(RegisterDto dto)
        {
            var isExistentUser = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (isExistentUser != null)
                return BaseDtoExtension.Invalid("Usuário já registrado");

            var resultOpenTime = new TimeOnly();
            if (TimeOnly.TryParse(dto.OpenTime, out resultOpenTime) == false)
                return BaseDtoExtension.Invalid("Horario de abertura inválido");

            var resultCloseTime = new TimeOnly();
            if (TimeOnly.TryParse(dto.CloseTime, out resultCloseTime) == false)
                return BaseDtoExtension.Invalid("Horario de fechamento inválido");

            var newUser = _factory.User.Create(dto.SaloonName, dto.UserName, dto.PhoneNumber, dto.Email, dto.CNPJ, dto.Password, new AddressEntity(),
                resultOpenTime, resultCloseTime, dto.GoogleMapsLocation);

            var address = new AddressEntity(dto.StreetName, dto.SaloonNumber, dto.City, dto.State, dto.Complement, dto.CEP, newUser.Id);

            newUser.Address = address;

            var validationResult = Validation.Verify(_userValidator.Validate(newUser));

            if (validationResult.Condition)
            {
                _userRepository.Create(newUser);
                return BaseDtoExtension.Sucess("conta criada com sucesso");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}