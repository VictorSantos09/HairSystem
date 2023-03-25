using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.ExceptionHandler;
using Hair.Application.Services.UserCases.ImageManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ImageController : ControllerBase
    {
        private readonly PostImageService _service;
        private readonly IException _exHelper;

        public ImageController(IApplicationDbContext<ImageEntity> imageRepository, IApplicationDbContext<UserEntity> userRepository,
            IException exception, IValidator<ImageEntity> imageValidator)
        {
            _exHelper = exception;
            _service = new(imageRepository, userRepository, imageValidator);
        }

        [HttpPost]
        [Route("PostImage")]
        public IActionResult PostImage([FromBody] PostImageDto dto)
        {
            try
            {
                var result = _service.Post(dto);
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