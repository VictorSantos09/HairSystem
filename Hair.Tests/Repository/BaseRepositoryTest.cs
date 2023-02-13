using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Repository
{
    public class BaseRepositoryTest
    {
        private readonly Mock<IBaseRepository<UserEntity>> _mock = new Mock<IBaseRepository<UserEntity>>();

        [Fact]
        public void GetAll_ShouldShowUsers_WhenExists()
        {
            var users = new List<UserEntity>();

            users.Add(It.IsAny<UserEntity>());

            _mock.Setup(x => x.GetAll()).Returns(users);

            var actual = _mock.Object.GetAll();

            Assert.Equal(1, actual.Count);

        }
    }
}