using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.UserAccountManagment
{
    /// <summary>
    /// Classe responsável por executar o cadastro de um novo usuário.
    /// </summary>
    public class RegisterService : IRegister
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserEntity> _userValidator;
        private readonly IFactory _factory;

        public RegisterService(IUserRepository userRepository, IValidator<UserEntity> userValidator, IFactory factory)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _factory = factory;
        }

        public BaseDto Register(RegisterDto dto)
        {
            UserEntity? isExistentUser = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (isExistentUser != null)
                return BaseDtoExtension.Invalid("Usuário já registrado");

            if (TimeOnly.TryParse(dto.OpenTime, out TimeOnly resultOpenTime) == false)
                return BaseDtoExtension.Invalid("Horario de abertura inválido");

            if (TimeOnly.TryParse(dto.CloseTime, out TimeOnly resultCloseTime) == false)
                return BaseDtoExtension.Invalid("Horario de fechamento inválido");

            AddressEntity emptyAddress = _factory.Address.Create();

            UserEntity newUser = _factory.User.Create(dto.SaloonName, dto.UserName, dto.PhoneNumber, dto.Email, dto.CNPJ, dto.Password, emptyAddress,
                resultOpenTime, resultCloseTime, dto.GoogleMapsLocation);

            AddressEntity address = _factory.Address.Create(dto.StreetName, dto.SaloonNumber, dto.City, dto.State, dto.Complement, dto.CEP, newUser.Id);

            newUser.Address = address;

            ValidationResultDto validationResult = Validation.Verify(_userValidator.Validate(newUser));

            if (validationResult.Condition)
            {
                _userRepository.Create(newUser);
                return BaseDtoExtension.Sucess("conta criada com sucesso");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}