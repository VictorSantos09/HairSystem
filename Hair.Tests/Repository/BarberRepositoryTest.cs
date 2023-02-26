﻿using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Repository
{
    public class BarberRepositoryTest
    {
        private readonly Mock<IBaseRepository<IBarber>> _mock = new Mock<IBaseRepository<IBarber>>();

        [Fact]
        public void Create_ShouldCreateBarber_WhenCalled()
        {
            var mockAdress = new AddressEntity("Rua das Palmeiras", "222", "Blumenau", "Santa Catarina", null);
            var entity = new BarberEntity("TestName", "TestPhoneNumber", "TestEmail", 200, mockAdress, true, Guid.NewGuid(), "TestSaloon");

            _mock.Setup(x => x.Create(entity)).Verifiable();

            _mock.Object.Create(entity);

            _mock.Verify(x => x.Create(entity), Times.Once());
        }

        [Fact]
        public void Update_ShouldUpdateBarber_WhenValid()
        {
            var mockAdress = new AddressEntity("Rua Pro", "666", "Blumenau", "Santa Catarina", null);
            var entity = new BarberEntity("TestName", "TestPhoneNumber", "TestEmail", 200, mockAdress, true, Guid.NewGuid(), "TestSaloon");

            _mock.Setup(x => x.Update(It.IsAny<BarberEntity>())).Callback((BarberEntity entity) =>
            {
                entity.Salary = 1200;
                entity.SaloonName = "CarlinHair";
            });

            _mock.Object.Update(entity);

            Assert.Equal(1200, entity.Salary);
            Assert.Equal("CarlinHair", entity.SaloonName);
        }
    }
}

