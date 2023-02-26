using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class RegisterController : ControllerBase
    {
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly RegisterService _service;

        public RegisterController(IBaseRepository<IUser> userRepository)
        {
            _userRepository = userRepository;
            _service = new(_userRepository);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var result = _service.Execute(dto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}