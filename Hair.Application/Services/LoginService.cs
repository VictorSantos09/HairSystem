using Hair.Application.Common;
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
        public BaseDto CheckLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return new BaseDto(406, "Email ou senha inválidos");

            var user = _userRepository.GetByEmail(email, password);

            if (user != null)
                return new BaseDto(200, "Login realizado com sucesso!", user.Id);

            return new BaseDto(404, "Usuario não encontrado");
        }
    }
}
