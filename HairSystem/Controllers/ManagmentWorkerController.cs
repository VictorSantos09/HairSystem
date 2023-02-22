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
    public class ManagmentWorkerController : ControllerBase
    {
        private readonly ManagmentWorkerService _service;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public ManagmentWorkerController(IBaseRepository<BarberEntity> barberRepository, IBaseRepository<UserEntity> userRepository)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_userRepository, _barberRepository);
        }

        [HttpPost]
        [Route("FireBarber")]
        public IActionResult FireBarber([FromBody] FireBarberDto dto)
        {
            var result = _service.Fire(dto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("HireBarber")]
        public IActionResult HireBarber([FromBody] HireBarberDto dto)
        {
            var result = _service.Hire(dto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("UpdateBarber")]
        public IActionResult ChangeAdress([FromBody] UpdateBarberDto dto)
        {
            var result = _service.Update(dto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}