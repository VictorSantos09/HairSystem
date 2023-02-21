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
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public ScheduleHaircutController(IBaseRepository<UserEntity> userRepository, IBaseRepository<HaircutEntity> haircutRepository)
        {
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
            _service = new(_userRepository, _haircutRepository);
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
