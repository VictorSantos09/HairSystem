using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ViewEmployeeDataController : ControllerBase
    {
        private readonly VisualizeEmployeeDataService _service;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IGetByEmail _userRepository;

        public ViewEmployeeDataController(IBaseRepository<BarberEntity> barberRepository, IGetByEmail userRepository)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_barberRepository, _userRepository);
        }

        [HttpPost]
        [Route("VisualizeEmployeeData")]
        public IActionResult Visualize([FromBody] VisualizeEmployeeDataDto dataDto)
        {
            var result = _service.GetEmployeeData(dataDto.Email, dataDto.Password);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
