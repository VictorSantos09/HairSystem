
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(IGetByEmail getByEmail)
        {
            _loginService = new(getByEmail);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var result = _loginService.CheckLogin(dto);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
