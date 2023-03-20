using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Services.UserCases.ImageManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class PostImageServiceTests
    {
        private readonly Mock<IBaseRepository<ImageEntity>> _mockImageRepository;
        private readonly Mock<IBaseRepository<UserEntity>> _mockUserRepository;
        private readonly PostImageService _postImageService;

        public PostImageServiceTests()
        {
            _mockImageRepository = new Mock<IBaseRepository<ImageEntity>>();
            _mockUserRepository = new Mock<IBaseRepository<UserEntity>>();
            _postImageService = new PostImageService(_mockImageRepository.Object, _mockUserRepository.Object, null);
        }

        [Fact]
        public void Post_WhenUserIsNull_ReturnsNotFoundError()
        {
            // Arrange
            var dto = new PostImageDto(Guid.NewGuid(), "image");

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns((UserEntity)null);

            // Act
            var actual = _postImageService.Post(dto);
            var expected = BaseDtoExtension.NotFound();

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Post_WhenImageIsNull_ReturnsNotNullError()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var dto = new PostImageDto(user.Id, null);

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            // Act
            var actual = _postImageService.Post(dto);
            var expected = BaseDtoExtension.NotNull("Imagem");

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }

        [Fact]
        public void Post_WhenImageIsNotNull_ReturnsSuccess()
        {
            // Arrange
            var user = new UserEntity { Id = Guid.NewGuid() };
            var imageData = new byte[] { 0x00, 0x01, 0x02 }; // substituir com o dado da imagem
            var hexString = BitConverter.ToString(imageData).Replace("-", "");
            var dto = new PostImageDto(user.Id, hexString);

            _mockUserRepository.Setup(repo => repo.GetById(dto.UserID)).Returns(user);

            // Act
            var actual = _postImageService.Post(dto);
            var expected = BaseDtoExtension.Sucess();

            // Assert
            Assert.Equal(expected._Message, actual._Message);
            Assert.Equal(expected._StatusCode, actual._StatusCode);
        }
    }
}