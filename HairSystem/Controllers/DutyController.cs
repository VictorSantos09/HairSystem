using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.ClientCases;
using Hair.Application.Dto.UserCases;
using Hair.Application.ExceptionHandler;
using Hair.Application.Services.ClientCases;
using Hair.Application.Services.UserCases.UserServiceManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class DutyController : ControllerBase
    {
        private readonly ScheduleDutyService _schedule;
        private readonly CancelDutyService _cancel;
        private readonly UpdateUserServiceService _changePrice;
        private readonly IException _exHelper;

        public DutyController(IApplicationDbContext<UserEntity> userRepository, IApplicationDbContext<ServiceOrderEntity> haircutRepository,
            IException exception, IValidator<ServiceOrderEntity> haircutValidator)
        {
            _exHelper = exception;
            _schedule = new ScheduleDutyService(userRepository, haircutRepository, haircutValidator);
            _cancel = new CancelDutyService(userRepository, haircutRepository);
            _changePrice = new UpdateTaskService(userRepository);
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
        [Route("CancelExistentDuty")]
        public IActionResult Cancel([FromBody] CancelDutyDto dto)
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
        [Route("ChangeServicePrice")]
        public IActionResult ChangePrice(UpdateUserServiceDto dto)
        {
            try
            {
                var result = _changePrice.Update(dto);
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