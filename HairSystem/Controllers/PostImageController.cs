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
    public class PostImageController : ControllerBase
    {
        private readonly PostImageService _service;
        private readonly IBaseRepository<IImage> _imageRepository;
        private readonly IBaseRepository<IUser> _userRepository;
        private readonly IException _exHelper;

        public PostImageController(IBaseRepository<IImage> imageRepository, IBaseRepository<IUser> userRepository, IException exception)
        {
            _exHelper = exception;
            _imageRepository = imageRepository;
            _userRepository = userRepository;

            _service = new(_imageRepository, _userRepository);
        }

        [HttpPost]
        [Route("PostImage")]
        public IActionResult PostImage([FromBody] PostImageDto dto)
        {
            try
            {
                var result = _service.Post(dto);
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