
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Exeception;
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
        private readonly IException _exHelper;

        public LoginController(IGetByEmail getByEmail, IException exception)
        {
            _exHelper = exception;
            _loginService = new(getByEmail);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
            {
                var result = _loginService.CheckLogin(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (ArgumentNullException e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }
    }
}