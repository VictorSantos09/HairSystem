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
    public class ViewSaloonInformationController : ControllerBase
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly ViewSaloonInformationService _service;

        public ViewSaloonInformationController(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
            _service = new(_userRepository);
        }

        [HttpPost]
        [Route("ViewInformation")]
        public IActionResult GetInformation([FromBody] ViewSaloonInformationDto dto)
        {
            var result = _service.GetInformation(dto);

            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
