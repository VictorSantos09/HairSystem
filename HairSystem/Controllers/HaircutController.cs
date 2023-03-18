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
    public class HaircutController : ControllerBase
    {
        private readonly ScheduleDutyService _schedule;
        private readonly CancelHaircutService _cancel;
        private readonly ChangePriceService _changePrice;
        private readonly IException _exHelper;

        public HaircutController(IBaseRepository<UserEntity> userRepository, IBaseRepository<DutyEntity> haircutRepository,
            IException exception, IValidator<DutyEntity> haircutValidator)
        {
            _exHelper = exception;
            _schedule = new ScheduleDutyService(userRepository, haircutRepository, haircutValidator);
            _cancel = new CancelHaircutService(userRepository, haircutRepository);
            _changePrice = new ChangePriceService(userRepository);
        }

        [HttpPost]
        [Route("Schedule")]
        public IActionResult Schedule([FromBody] ScheduleDutyDto dto)
        {
            try
            {
                var result = _schedule.Schedule(dto);
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
        [Route("CancelExistentHaircut")]
        public IActionResult Cancel([FromBody] CancelHaircutDto dto)
        {
            try
            {
                var result = _cancel.Cancel(dto);
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
                return StatusCode(info._StatusCode, info._Data);
            }
        }

        [HttpPut]
        [Route("ChangeHaircutePrice")]
        public IActionResult ChangePrice(ChangePriceDto dto)
        {
            try
            {
                var result = _changePrice.ChangeHaircutePrice(dto);
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