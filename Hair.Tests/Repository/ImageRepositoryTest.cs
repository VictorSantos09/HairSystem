using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Repository
{
    public class ImageRepositoryTest
    {
        private readonly Mock<IBaseRepository<ImageEntity>> _mock = new Mock<IBaseRepository<ImageEntity>>();

    }
}