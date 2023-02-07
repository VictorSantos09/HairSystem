using Hair.Application.Common;
using Hair.Repository.Repositories;

namespace Hair.Application.Services
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public BaseDto CheckLogin(string email, string password)
        {
            if (email == null)
                return new BaseDto(406, "Email ou senha inválidos");

            var user = _userRepository.GetAll().Find(x => x.Email == email && x.Password == password);

            if (user != null)
                return new BaseDto(200, "Login realizado com sucesso!", user.Id);

            return new BaseDto(404, "Usuario não encontrado");
        }
    }
}
