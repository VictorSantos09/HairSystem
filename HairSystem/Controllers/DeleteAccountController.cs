using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class DeleteAccountController : ControllerBase
    {
        private readonly DeleteAccountService _service;
        private readonly IException _exHelper;

        public DeleteAccountController(IGetByEmail getByEmail, IException exception)
        {
            _exHelper = exception;
            _service = new(getByEmail);
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public IActionResult Delete([FromBody] DeleteAccountDto dto)
        {
            try
            {
                var result = _service.Delete(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));
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