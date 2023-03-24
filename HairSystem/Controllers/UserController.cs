using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Interfaces.UserCases;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UserController : ControllerBase
    {
        private readonly IRegister _register;
        private readonly ILogin _login;
        private readonly IDeleteAccount _deleteAccount;
        private readonly IException _exHelper;

        public UserController(IRegister register, ILogin login, IDeleteAccount deleteAccount, IException exHelper)
        {
            _register = register;
            _login = login;
            _deleteAccount = deleteAccount;
            _exHelper = exHelper;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            try
            {
                var result = _register.Register(dto);
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

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
            {
                var result = _login.Login(dto);
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

        [HttpDelete]
        [Route("DeleteAccount")]
        public IActionResult Delete([FromBody] DeleteAccountDto dto)
        {
            try
            {
                var result = _deleteAccount.Delete(dto);
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
