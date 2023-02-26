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
    public class ViewSaloonInformationController : ControllerBase
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly ViewSaloonInformationService _service;
        private readonly IException _exHelper;

        public ViewSaloonInformationController(IBaseRepository<UserEntity> userRepository, IException exception)
        {
            _exHelper = exception;
            _userRepository = userRepository;
            _service = new(_userRepository);
        }

        [HttpPost]
        [Route("ViewInformation")]
        public IActionResult GetInformation([FromBody] ViewSaloonInformationDto dto)
        {
            try
            {
                var result = _service.GetInformation(dto);
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
