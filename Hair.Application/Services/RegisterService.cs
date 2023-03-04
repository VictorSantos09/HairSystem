using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validation;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        private readonly IValidator<UserEntity> _validator;

        public RegisterService(IGetByEmail userRepository, IValidator<UserEntity> validator)
        {
            _validator = validator;
            _userRepository = userRepository;
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
            //var isExistentUser = _userRepository.GetByEmail(dto.Email, dto.Password);

            //if (isExistentUser != null)
            //    return BaseDtoExtension.Invalid("Usuário já registrado");

            //DateTime openTime;
            //if (!DateTime.TryParse(dto.OpenTime.ToString(), out openTime))
            //    return BaseDtoExtension.Invalid("Horário de abertura inválido");

            //DateTime closeTime;
            //if (!DateTime.TryParse(dto.CloseTime.ToString(), out closeTime))
            //    return BaseDtoExtension.Invalid("Horário de fechamento inválido");

            var address = new AddressEntity(dto.StreetName, dto.SaloonNumber, dto.City, dto.State, dto.Complement);

            var haircutPrice = new HaircutPriceEntity(dto.HairPrice, dto.BeardPrice, dto.MustachePrice);

            var newUser = new UserEntity(dto.SaloonName, dto.Name, dto.PhoneNumber, dto.Email, dto.Password, address, dto.CNPJ, haircutPrice, dto.OpenTime, dto.GoogleMapsSource, dto.CloseTime);

            var result = _validator.Validate(newUser);

            if (!result.IsValid)
            {
                return BaseDtoExtension.Create(400, "Dados inválidos", result.Errors);
            }

            _userRepository.Create(newUser);

            return BaseDtoExtension.Sucess("Conta Criada com sucesso");
        }

        private static bool IsValidEmail(string email)
        {
            if (email == null)
                return false;

            if (ValidatorEmailFormat(email))
                return true;

            return false;
        }

        private static bool ValidatorEmailFormat(string email)
        {
            string[] formats = { "@HOTMAIL.COM", "@GMAIL.COM", "@YAHOO.COM.BR", @"OUTLOOK.COM", "@ICLOUD.COM" };

            foreach (var item in formats)
            {
                if (email.ToUpper().Contains(item))
                    return true;
            }

            return false;
        }
    }
}