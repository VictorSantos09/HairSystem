using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.UserAccountManagment
{
    /// <summary>
    /// Responsável por efetuar o login do usuário.
    /// </summary>
    public class LoginService : ILogin
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Login(LoginDto dto)
        {
            if (Validation.NotEmpty(dto.Password) || Validation.NotEmpty(dto.Email))
                return new BaseDto(406, "Email ou senha inválidos");

            UserEntity? user = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (user != null)
                return new BaseDto(200, "Login realizado com sucesso!", new { Successful = true, UserId = user.Id });

            return new BaseDto(404, "Usuario não encontrado", new { Successful = false, Message = "Usuario não encontrado" });
        }
    }
}