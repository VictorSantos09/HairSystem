
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly UserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new();
            _loginService = new LoginService(_userRepository);
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _loginService.CheckLogin(loginDto.Email, loginDto.Password);

            if (result._StatusCode == 200)
                return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : new { Successful = true, Id = result._Data });

            return StatusCode(result._StatusCode, new { Message = result._Message, Successful = false });
        }
    }
}
