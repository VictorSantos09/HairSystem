using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Repository
{
    public class HaircutRepositoryTest
    {
        private readonly Mock<IBaseRepository<IHaircut>> _mock = new Mock<IBaseRepository<IHaircut>>();

        [Fact]
        public void Create_ShouldCreateHaircute_WhenCalled()
        {
            var entity = new HaircutEntity(Guid.NewGuid(), DateTime.Now, true, null);

            _mock.Setup(x => x.Create(entity)).Verifiable();

            _mock.Object.Create(entity);

            _mock.Verify(x => x.Create(entity), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateHaircute_WhenValid()
        {
            var entity = new HaircutEntity(Guid.NewGuid(), DateTime.Now, true, null);

            _mock.Setup(x => x.Update(It.IsAny<HaircutEntity>())).Callback((HaircutEntity entity) =>
            {
                entity.Avaible = false;
            });

            _mock.Object.Update(entity);

            Assert.Equal(false, entity.Avaible);
        }
    }
}

