using Hair.Application.Dto;
using Hair.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChangePriceController : ControllerBase
    {
        private readonly ChangePriceService _changePrice;

        public ChangePriceController(ChangePriceService changePrice)
        {
            _changePrice = changePrice;
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