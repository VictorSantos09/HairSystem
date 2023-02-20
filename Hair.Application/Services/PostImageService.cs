using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class PostImageService
    {
        private readonly IBaseRepository<ImageEntity> _imageRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public PostImageService(IBaseRepository<ImageEntity> imageRepository, IBaseRepository<UserEntity> userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }

        public BaseDto Post(PostImageDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (dto.Image == null)
                return BaseDtoExtension.NotNull("Imagem");

            byte[] imageByte = Convert.FromHexString(dto.Image.ToString());

            var img = new ImageEntity(user.Id, imageByte);

            _imageRepository.Create(img);

            return BaseDtoExtension.Sucess();
        }
    }
}
