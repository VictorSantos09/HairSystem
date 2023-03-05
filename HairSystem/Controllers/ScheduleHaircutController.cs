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
    public class ScheduleHaircutController : ControllerBase
    {
        private ScheduleHaircutService _service;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;
        private readonly IException _exHelper;

        public ScheduleHaircutController(IBaseRepository<UserEntity> userRepository, IBaseRepository<HaircutEntity> haircutRepository,
            IException exception, IValidator<HaircutEntity> haircutValidator)
        {
            _exHelper = exception;
            _userRepository = userRepository;
            _haircutRepository = haircutRepository;
            _service = new(_userRepository, _haircutRepository, haircutValidator);
        }

        [HttpPost]
        [Route("ScheduleHaircut")]
        public IActionResult Schedule([FromBody] ScheduleHaircutDto dto)
        {
            try
            {
                var result = _service.Schedule(dto);
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