using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Repository
{
    public class SaloonItemRepositoryTest
    {
        private readonly Mock<IBaseRepository<SaloonItemEntity>> _mock = new Mock<IBaseRepository<SaloonItemEntity>>();

        [Fact]
        public void Create_ShouldCreateSaloonItem_WhenCalled()
        {
            var entity = new SaloonItemEntity("Navalha", 20, 12);

            _mock.Setup(x => x.Create(entity)).Verifiable();

            _mock.Object.Create(entity);

            _mock.Verify(x => x.Create(entity), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateSaloonItem_WhenValid()
        {
            var saloonItemEntity = new SaloonItemEntity("Navalha", 20, 12);

            _mock.Setup(x => x.Update(It.IsAny<SaloonItemEntity>())).Callback((SaloonItemEntity entity) =>
            {
                entity.Name = "Razor";
                entity.QuantityAvaible = 30;
            });

            _mock.Object.Update(saloonItemEntity);

            Assert.Equal("Razor", saloonItemEntity.Name);
            Assert.Equal(30, saloonItemEntity.QuantityAvaible);
        }
    }
}
