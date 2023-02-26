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
    public class ChangePriceController : ControllerBase
    {
        private readonly ChangePriceService _changePrice;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IException _exHelper;

        public ChangePriceController(IBaseRepository<UserEntity> userRepository, IException exception)
        {
            _exHelper = exception;
            _userRepository = userRepository;
            _changePrice = new ChangePriceService(_userRepository);
        }

        [HttpPost]
        [Route("ChangeHaircutePrice")]
        public IActionResult ChangePrice(ChangePriceDto dto)
        {
            try
            {
                var result = _changePrice.ChangeHaircutePrice(dto);
                return StatusCode(result._StatusCode, new MessageDto(result._Message));
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