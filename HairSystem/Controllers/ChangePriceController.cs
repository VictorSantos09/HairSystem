using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangePriceController : ControllerBase
    {
        private readonly ChangePriceService _changePrice;
        private readonly UserRepository _userRepository;

        public ChangePriceController(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _changePrice = new ChangePriceService(_userRepository);
        }

        [HttpPost]
        [Route("ChangeHaircutePrice")]
        public IActionResult ChangePrice(ChangePriceDto priceDto)
        {
            var result = _changePrice.ChangeHaircutePrice(priceDto.NewPrice, priceDto.SaloonId, priceDto.Confirmed, priceDto.Hair, priceDto.Mustache, priceDto.Beard);

            return StatusCode(result._StatusCode, new MessageDto { Message = result._Message });
        }
    }
}