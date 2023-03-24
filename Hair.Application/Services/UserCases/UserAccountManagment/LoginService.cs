using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Application.Services.UserCases.UserAccountManagment
{
    /// <summary>
    /// Define as funções para efetuar o login.
    /// </summary>
    public class LoginService : ILogin
    {
        private readonly IGetByEmailDbContext _userRepository;

        public LoginService(IGetByEmailDbContext userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Login(LoginDto dto)
        {
            if (Validation.NotEmpty(dto.Password) || Validation.NotEmpty(dto.Email))
                return new BaseDto(406, "Email ou senha inválidos");

            var user = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (user != null)
                return new BaseDto(200, "Login realizado com sucesso!", new { Successful = true, UserId = user.Id });

            return new BaseDto(404, "Usuario não encontrado", new { Successful = false, Message = "Usuario não encontrado" });
        }
    }
}