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
    public class CancelHaircutController : ControllerBase
    {
        private readonly CancelHaircutService _service;
        private readonly IException _exHelper;
        public CancelHaircutController(IBaseRepository<UserEntity> baseRepository, IBaseRepository<HaircutEntity> haircutRepository, IException exception)
        {
            _exHelper = exception;
            _service = new(baseRepository, haircutRepository);
        }

        [HttpPost]
        [Route("CancelExistentHaircut")]
        public IActionResult Cancel([FromBody] CancelHaircutDto dto)
        {
            try
            {
                var result = _service.Cancel(dto);
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
    }
}