using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class PostImageController : ControllerBase
    {
        private readonly PostImageService _service;
        private readonly IBaseRepository<ImageEntity> _imageRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public PostImageController(IBaseRepository<ImageEntity> imageRepository, IBaseRepository<UserEntity> userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;

            _service = new(_imageRepository, _userRepository);
        }

        [HttpPost]
        [Route("PostImage")]
        public IActionResult PostImage([FromBody] PostImageDto dto)
        {
            var result = _service.Post(dto);

            return StatusCode(result._StatusCode, result._Message);
        }
    }
}
