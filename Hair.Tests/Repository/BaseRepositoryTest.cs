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


        [Fact]
        public void GetById_ShouldReturnUser_WhenExists()
        {
            var user = new UserEntity();
            var id = Guid.NewGuid();

            _mock.Setup(x => x.GetById(id)).Returns(user);

            var actual = _mock.Object.GetById(id);

            Assert.Equal(user, actual);
        }

        [Fact]
        public void Create_ShouldCreateUser_WhenCalled()
        {
            var user = new UserEntity();

            _mock.Setup(x => x.Create(user)).Verifiable();

            _mock.Object.Create(user);

            _mock.Verify(x => x.Create(user), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateUser_WhenValid()
        {
            var user = new UserEntity("CarlosHair", "Carlin", null, null, null, null, null, null);

            _mock.Setup(x => x.Update(It.IsAny<UserEntity>())).Callback((UserEntity userEntity) =>
            {
                userEntity.SaloonName = "CarlosHair";
                userEntity.OwnerName = "Carlin";
            });

            _mock.Object.Update(user);

            Assert.Equal("CarlosHair", user.SaloonName);
            Assert.Equal("Carlin", user.OwnerName);
        }


        [Fact]
        public void Delete_ShouldRemoveUser_WhenExists()
        {
            var users = new List<UserEntity>();

            var user = new UserEntity("CarlosTeste", "CarlinTeste", null, null, null, null, null, null);

            users.Add(user);

            _mock.Setup(x => x.Remove(It.IsAny<Guid>()))
                 .Callback((Guid id) => users.Remove(users.FirstOrDefault(x => x.Id == id)));

            _mock.Object.Remove(user.Id);

            Assert.Equal(0, users.Count);
        }
    }
}