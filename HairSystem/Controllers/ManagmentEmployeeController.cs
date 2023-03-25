using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.ExceptionHandler;
using Hair.Application.Interfaces.UserCases;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ManagmentEmployeeController : ControllerBase
    {
        private readonly IEmployeeManagment _service;
        private readonly IException _exHelper;

        public ManagmentEmployeeController(IEmployeeManagment service, IException exHelper)
        {
            _service = service;
            _exHelper = exHelper;
        }

        [HttpDelete]
        [Route("FireWorker")]
        public IActionResult FireWorker([FromBody] DeleteEmployeeDto dto)
        {
            try
            {
                var result = _service.Fire(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPost]
        [Route("HireWorker")]
        public IActionResult HireWorker([FromBody] CreateEmployeeDto dto)
        {
            try
            {
                var result = _service.Hire(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPut]
        [Route("UpdateWorker")]
        public IActionResult UpdateWorker([FromBody] UpdateEmployeeDto dto)
        {
            try
            {
                var result = _service.Update(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }
    }
}