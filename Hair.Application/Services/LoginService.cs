using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class LoginService
    {
        private readonly IGetByEmail _userRepository;

        public LoginService(IGetByEmail userRepository)
        {
            _userRepository = userRepository;
        }
        public BaseDto CheckLogin(LoginDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                return new BaseDto(406, "Email ou senha inválidos");

            var user = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (user != null)
                return new BaseDto(200, "Login realizado com sucesso!", new { Successful = true, UserId = user.Id });

            return new BaseDto(404, "Usuario não encontrado", new { Successful = false, Message = "Usuario não encontrado" });
        }
    }
}