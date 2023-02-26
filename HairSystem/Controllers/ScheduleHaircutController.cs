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
    public class ScheduleHaircutController : ControllerBase
    {
        private ScheduleHaircutService _service;
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IBaseRepository<IHaircut> _haircutRepository;

        public ScheduleHaircutController(IBaseRepository<IUser> userRepository, IBaseRepository<IHaircut> haircutRepository)
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

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}
