using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Define a função de postar uma nova imagem
    /// </summary>
    public class PostImageService
    {
        private readonly IBaseRepository<ImageEntity> _imageRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;

        public PostImageService(IBaseRepository<ImageEntity> imageRepository, IBaseRepository<UserEntity> userRepository)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua a postagem de uma nova imagem para o usuário
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada</returns>
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