using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Exeception;
using Hair.Application.Functions;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Functions
{
    [ApiController]
    [Route("api/SearchSaloon")]
    public class SearchSaloonController : ControllerBase
    {
        private readonly SearchSaloonFunction _function;
        private readonly IException _exHelper;

        public SearchSaloonController(IBaseRepository<IUser> userRepository, IException exception)
        {
            _exHelper = exception;
            _function = new(userRepository);
        }

        [HttpPost]
        [Route("SearchSaloonFiltered")]
        public IActionResult FilterSaloon([FromBody] SearchSaloonFilterDto dto)
        {
            try
            {
                var result = _function.Filtered(dto);
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

        [HttpPost]
        [Route("SearchSaloonSimple")]
        public IActionResult SimpleSearch([FromBody] SearchSaloonSimpleDto dto)
        {
            try
            {
                var result = _function.SimpleSearch(dto);
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