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
    public class ViewDataController : ControllerBase
    {
        private readonly VisualizeEmployeeDataService _viewEmployeeData;
        private readonly ViewHaircutTimeService _viewHaircutTime;
        private readonly IException _exHelper;

        public ViewDataController(IBaseRepository<BarberEntity> barberRepository, IGetByEmail userRepository, 
            IException exception, IBaseRepository<HaircutEntity> haircutRepository)
        {
            _exHelper = exception;
            _viewEmployeeData = new VisualizeEmployeeDataService(barberRepository, userRepository);
            _viewHaircutTime = new ViewHaircutTimeService(haircutRepository);
        }

        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeEmployeeDataDto dataDto)
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
        public IActionResult GetScheduledHaircuts([FromBody] ViewHaircutTimeDto dto)
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
