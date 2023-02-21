using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controler")]
    public class RegisterController : ControllerBase
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly RegisterService _service;

        public RegisterController(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
            _service = new(_userRepository);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var result = _service.Execute(dto);

            return StatusCode(result._StatusCode, new { Message = result._Message });
        }
    }
}