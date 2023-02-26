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
    public class ViewEmployeeDataController : ControllerBase
    {
        private readonly VisualizeEmployeeDataService _service;
        private readonly IBaseRepository<IBarber> _barberRepository;
        private readonly IGetByEmail _userRepository;
        private readonly IException _exHelper;

        public ViewEmployeeDataController(IBaseRepository<IBarber> barberRepository, IGetByEmail userRepository, IException exception)
        {
            _exHelper = exception;
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_barberRepository, _userRepository);
        }

        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeEmployeeDataDto dataDto)
        {
            try
            {
            var result = _service.GetEmployeeData(dataDto.Email, dataDto.Password);
            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch(ArgumentNullException e)
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
