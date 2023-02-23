using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewHaircutTimeController : ControllerBase
    {
        private readonly ViewHaircutTimeService _service;

        public ViewHaircutTimeController(IBaseRepository<HaircutEntity> haircutRepository)
        {
            _service = new ViewHaircutTimeService(haircutRepository);
        }

        [HttpPost]
        [Route("GetHaircutTime")]
        public IActionResult GetHaircutTime([FromBody] ViewHaircutTimeDto dto)
        {
            var result = _service.GetHaircutTime(dto);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
