using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService _service;
        private readonly IException _exHelper;

        public RegisterController(IGetByEmail userRepository, IException exception)
        {
            _exHelper = exception;
            _service = new(userRepository);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            try
            {
                var result = _service.Execute(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));

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