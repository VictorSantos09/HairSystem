using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services;
using Hair.Domain.Entities;
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

        public RegisterController(IGetByEmail userRepository, IException exception, IValidator<UserEntity> validator)
        {
            _exHelper = exception;
            _service = new(userRepository, validator);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            try
            {
                var result = _service.Execute(dto);
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