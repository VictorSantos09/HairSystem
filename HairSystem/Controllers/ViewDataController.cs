using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services.UserCases;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ViewDataController : ControllerBase
    {
        private readonly ViewWorkerDataService _viewEmployeeData;
        private readonly ViewDutyTimeService _viewHaircutTime;
        private readonly IException _exHelper;

        public ViewDataController(IBaseRepository<WorkerEntity> workerRepository, IGetByEmail userRepository, 
            IException exception, IBaseRepository<DutyEntity> haircutRepository)
        {
            _exHelper = exception;
            _viewEmployeeData = new ViewWorkerDataService(workerRepository, userRepository);
            _viewHaircutTime = new ViewDutyTimeService(haircutRepository);
        }

        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeWorkerDataDto dataDto)
        {
            try
            {
                var result = _viewEmployeeData.GetWorkerData(dataDto.Email, dataDto.Password);
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