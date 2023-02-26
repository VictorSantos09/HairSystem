using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Exeception;
using Hair.Application.Services;
using Hair.Domain.Interfaces;
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
        public CancelHaircutController(IBaseRepository<IUser> baseRepository, IBaseRepository<IHaircut> haircutRepository, IException exception)
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
                return StatusCode(info._StatusCode, info._Data);
            }
        }
    }
}