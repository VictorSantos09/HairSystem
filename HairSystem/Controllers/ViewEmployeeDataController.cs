using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    public class ViewEmployeeDataController : ControllerBase
    {
        private readonly VisualizeEmployeeDataService _getEmployeeData;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IGetByEmail _userRepository;

        public ViewEmployeeDataController(IBaseRepository<BarberEntity> barberRepository, IGetByEmail userRepository)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _getEmployeeData = new(_barberRepository, _userRepository);
        }

        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeEmployeeDataDto dataDto)
        {
            var result = _getEmployeeData.GetEmployeeData(dataDto.Email, dataDto.Password);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message): result._Data);
        }
    }
}
