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
    public class ManagmentWorkerController : ControllerBase
    {
        private readonly ManagmentWorkerService _service;
        private readonly IBaseRepository<IBarber> _barberRepository;
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IException _exHelper;

        public ManagmentWorkerController(IBaseRepository<IBarber> barberRepository, IBaseRepository<IUser> userRepository, IException exception)
        {
            _exHelper = exception;
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_userRepository, _barberRepository);
        }

        [HttpPost]
        [Route("FireBarber")]
        public IActionResult FireBarber([FromBody] FireBarberDto dto)
        {
            try
            {
                var result = _service.Fire(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPost]
        [Route("HireBarber")]
        public IActionResult HireBarber([FromBody] HireBarberDto dto)
        {
            try
            {
                var result = _service.Hire(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPost]
        [Route("UpdateBarber")]
        public IActionResult ChangeAdress([FromBody] UpdateBarberDto dto)
        {
            try
            {
                var result = _service.Update(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }
    }
}