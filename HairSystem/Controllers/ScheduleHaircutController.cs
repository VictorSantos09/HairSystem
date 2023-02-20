using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ScheduleHaircutController : ControllerBase
    {
        private ScheduleHaircutService _service;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public ScheduleHaircutController(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
            _service = new(_userRepository);
        }

        [HttpPost]
        [Route("ScheduleHaircut")]
        public IActionResult Schedule([FromBody] ScheduleHaircutDto dto)
        {
            var result = _service.Schedule(dto);

            return StatusCode(result._StatusCode, result._Message);
        }
    }
}
