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
    public class HaircuteRepositoryTest
    {
        private readonly Mock<IBaseRepository<HaircuteEntity>> _mock = new Mock<IBaseRepository<HaircuteEntity>>();

        [Fact]
        public void Create_ShouldCreateHaircute_WhenCalled()
        {
            var entity = new HaircuteEntity(Guid.NewGuid(), null, true, null);

            _mock.Setup(x => x.Create(entity)).Verifiable();

            _mock.Object.Create(entity);

            _mock.Verify(x => x.Create(entity), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateHaircute_WhenValid()
        {
            var entity = new HaircuteEntity(Guid.NewGuid(), null, true, null);

            _mock.Setup(x => x.Update(It.IsAny<HaircuteEntity>())).Callback((HaircuteEntity entity) =>
            {
                entity.Avaible = false;
            });

            _mock.Object.Update(entity);

            Assert.Equal(false, entity.Avaible);
        }
    }
}

