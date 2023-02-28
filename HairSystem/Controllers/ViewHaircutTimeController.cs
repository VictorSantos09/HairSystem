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
    [Route("api/[controller]")]
    public class ViewHaircutTimeController : ControllerBase
    {
        private readonly ViewHaircutTimeService _service;
        private readonly IException _exHelper;

        public ViewHaircutTimeController(IBaseRepository<HaircutEntity> haircutRepository, IException exception)
        {
            _exHelper = exception;
            _service = new ViewHaircutTimeService(haircutRepository);
        }

        [HttpPost]
        [Route("GetScheduledHaircuts")]
        public IActionResult GetScheduledHaircuts([FromBody] ViewHaircutTimeDto dto)
        {
            try
            {
                var result = _service.GetScheduledHaircuts(dto);
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
