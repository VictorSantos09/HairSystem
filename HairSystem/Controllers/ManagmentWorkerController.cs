using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class ManagmentWorkerController : ControllerBase
    {
        private readonly ManagmentWorkerService _service;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public ManagmentWorkerController(IBaseRepository<BarberEntity> barberRepository, IBaseRepository<UserEntity> userRepository)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_userRepository,_barberRepository);
        }

        [HttpPost]
        [Route("FireBarber")]
        public IActionResult FireBarber([FromBody]FireBarberDto fireBarberDto)
        {
            var result = _service.FireBarber(fireBarberDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("HireBarber")]
        public IActionResult HireBarber([FromBody]HireBarberDto hireBarberDto)
        {
            var result = _service.HireNewbarber(hireBarberDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("ChangeBarberAdress")]
        public IActionResult ChangeAdress([FromBody] ChangeBarberAddressDto adressDto)
        {
            var result = _service.ChangeBarberAddress(adressDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("ChangeBarberName")]
        public IActionResult ChangeName([FromBody] ChangeBarberNameDto nameDto)
        {
            var result = _service.ChangeBarberName(nameDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }

        [HttpPost]
        [Route("ChangeBarberSalary")]
        public IActionResult ChangeSalary([FromBody] ChangeBarberSalaryDto salaryDto)
        {
            var result = _service.ChangeBarberSalary(salaryDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}
