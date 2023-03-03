using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Define as funções para efetuar o login.
    /// 
    /// </summary>
    public class LoginService
    {
        private readonly IGetByEmail _userRepository;

        public LoginService(IGetByEmail userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua o processo de login.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com as credenciais de login.</param>
        /// 
        /// <returns>Retorna o login em caso de sucesso ou inválido.</returns>
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