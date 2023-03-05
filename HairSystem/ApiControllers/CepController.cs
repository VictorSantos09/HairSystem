using Hair.Application.ApiRequest;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.ApiControllers
{
    [ApiController]
    [Route("api/controller")]
    public class CepController : ControllerBase
    {
        private readonly CepService _service;
        private readonly IException _exHelper;

        public CepController(IApiRequest baseRequest, IException exception)
        {
            _exHelper = exception;
            _service = new CepService(baseRequest);
        }

        [HttpPost]
        [Route("GetCepByCode")]
        public ActionResult Get([FromBody] GetCepDto dto)
        {
            try
            {
                var result = _service.GetCep(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var result = _exHelper.Error(e);
                return StatusCode(result._StatusCode, result._Data);
            }
        }
    }
}
