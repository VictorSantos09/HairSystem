using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Tests.Repository
{
    public class ImageRepositoryTest
    {
        private readonly Mock<IBaseRepository<ImageEntity>> _mock = new Mock<IBaseRepository<ImageEntity>>();

        [Fact]
        public void Create_ShouldCreateImage_WhenCalled()
        {
            var entity = new ImageEntity(Guid.NewGuid(), "TestSource", "TestObject");

            _mock.Setup(x => x.Create(entity)).Verifiable();

            _mock.Object.Create(entity);

            _mock.Verify(x => x.Create(entity), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateSaloonItem_WhenValid()
        {
            var entity = new ImageEntity(Guid.NewGuid(), "Test", "Test");

            _mock.Setup(x => x.Update(It.IsAny<ImageEntity>())).Callback((ImageEntity entity) =>
            {
                entity.Source = "TestSource";
                entity.Img = "TestObject";
            });

            _mock.Object.Update(entity);

            Assert.Equal("TestSource",entity.Source);
            Assert.Equal("TestObject", entity.Img);
        }
    }
}
