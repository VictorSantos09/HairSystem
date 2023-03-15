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
    /// Classe responsavel por executar o cadastro de novos usuários
    /// 
    /// </summary>
    public class RegisterService
    {
        private readonly IGetByEmail _userRepository;
        private readonly IValidator<UserEntity> _userValidator;

        public RegisterService(IGetByEmail userRepository, IValidator<UserEntity> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        /// <summary>
        /// 
        /// Efetua a criação de um novo usuário.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com sucesso quando concluido.</returns>
        public BaseDto Execute(RegisterDto dto)
        {
            var isExistentUser = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (isExistentUser != null)
                return BaseDtoExtension.Invalid("Usuário já registrado");

            var resultOpenTime = new TimeOnly();
            if (TimeOnly.TryParse(dto.OpenTime,out resultOpenTime) == false)
                return BaseDtoExtension.Invalid("Horario de abertura");

            var resultCloseTime = new TimeOnly();
            if (TimeOnly.TryParse(dto.CloseTime, out resultCloseTime) == false)
                return BaseDtoExtension.Invalid("Horario de fechamento");

            var haircutPrice = new HaircutPriceEntity(dto.HairPrice, dto.BeardPrice, dto.MustachePrice);

            var newUser = new UserEntity(dto.SaloonName, dto.Name, dto.PhoneNumber, dto.Email, dto.Password, new AddressEntity(),
                dto.CNPJ, haircutPrice, TimeOnly.Parse(dto.OpenTime), dto.GoogleMapsSource, TimeOnly.Parse(dto.CloseTime));

            var address = new AddressEntity(dto.StreetName, dto.SaloonNumber, dto.City, dto.State, dto.Complement, dto.CEP, newUser.Id);

            newUser.Address = address;

            var validationResult = Validation.Verify(_userValidator.Validate(newUser));

            if (validationResult.Condition)
            {
                _userRepository.Create(newUser);
                return BaseDtoExtension.Sucess("Conta Criada com sucesso");
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}