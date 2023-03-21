using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ViewEmpolyeeDataController : ControllerBase
    {
        private readonly ViewEmployeeDataService _viewEmployeeData;
        private readonly ViewServiceOrderService _viewHaircutTime;
        private readonly IException _exHelper;


        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeWorkerDataDto dataDto)
        {
            try
            {
                var result = _viewEmployeeData.GetEmployeeData(dataDto.Email, dataDto.Password);
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

        [HttpPost]
        [Route("GetScheduledHaircuts")]
        public IActionResult GetScheduledHaircuts([FromBody] ViewDutyTimeDto dto)
        {
            try
            {
                var result = _viewHaircutTime.GetScheduledHaircuts(dto);
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