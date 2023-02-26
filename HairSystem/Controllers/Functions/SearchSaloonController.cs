using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Functions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers.Functions
{
    [ApiController]
    [Route("api/SearchSaloon")]
    public class SearchSaloonController : ControllerBase
    {
        private readonly SearchSaloonFunction _function;

        public SearchSaloonController(IBaseRepository<UserEntity> userRepository)
        {
            _function = new(userRepository);
        }

        [HttpPost]
        [Route("SearchSaloonFiltered")]
        public IActionResult FilterSaloon([FromBody] SearchSaloonFilterDto dto)
        {
            var result = _function.Filtered(dto);
            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }

        [HttpPost]
        [Route("SearchSaloonSimple")]
        public IActionResult SimpleSearch([FromBody] SearchSaloonSimpleDto dto)
        {
            var result = _function.SimpleSearch(dto);
            return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}