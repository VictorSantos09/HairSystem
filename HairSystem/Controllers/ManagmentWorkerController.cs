using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class ManagmentWorkerController : ControllerBase
    {
        private readonly ManagmentWorkerService _service;

        public ManagmentWorkerController(BarberRepository barberRepository, UserRepository userRepository)
        {
            _service = new ManagmentWorkerService(userRepository, barberRepository);
        }
        [HttpPost]
        [Route("FireBarber")]
        public IActionResult FireBarber(FireBarberDto fireBarberDto)
        {
            var result = _service.FireBarber(fireBarberDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
        [HttpPost]
        [Route("HireBarber")]
        public IActionResult HireBarber(HireBarberDto hireBarberDto)
        {
            var result = _service.HireNewbarber(hireBarberDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
        [HttpPost]
        [Route("ChangeBarberAdress")]
        public IActionResult ChangeAdress(ChangeBarberAddressDto adressDto)
        {
            var result = _service.ChangeBarberAddress(adressDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
        [HttpPost]
        [Route("ChangeBarberName")]
        public IActionResult ChangeName(ChangeBarberNameDto nameDto)
        {
            var result = _service.ChangeBarberName(nameDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
        [HttpPost]
        [Route("ChangeBarberSalary")]
        public IActionResult ChangeSalary(ChangeBarberSalaryDto salaryDto)
        {
            var result = _service.ChangeBarberSalary(salaryDto);

            return StatusCode(result._StatusCode, new MessageDto(result._Message));
        }
    }
}
