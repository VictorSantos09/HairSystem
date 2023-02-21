
using Hair.Application.Common;
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
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var result = _loginService.CheckLogin(dto);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
