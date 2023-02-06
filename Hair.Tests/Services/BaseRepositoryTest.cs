using Hair.Domain.Common;
using static Dapper.SqlMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hair.Repository.Repositories;
using Moq;
using Xunit;
using Hair.Repository.Interfaces;
using Hair.Domain.Entities;

namespace Hair.Repository.Tests
{
    public class BaseRepositoryTest
    {
        private readonly Mock<IBaseRepository<BaseEntity>> _mockRepository;
        private readonly BaseEntity _entity;

        public BaseRepositoryTest()
        {
            _mockRepository = new Mock<IBaseRepository<BaseEntity>>("ENTITY");
            _entity = new BaseEntity { Id = Guid.NewGuid() };
        }

        [Fact]
        public void Remove_RemovesEntityFromDatabase()
        {
            _mockRepository.Setup(x => x.Remove(_entity.Id));

            _mockRepository.Object.Remove(_entity.Id);

            _mockRepository.Verify(x => x.Remove(_entity.Id), Times.Once());
        }

        [Fact]
        public void GetAll_ReturnsAllEntitiesFromDatabase()
        {
            var entities = new List<BaseEntity> { _entity };

            _mockRepository.Setup(x => x.GetAll()).Returns(entities);

            var result = _mockRepository.Object.GetAll();

            Assert.Equal(entities, result);
        }

        [Fact]
        public void GetById_ReturnsEntityWithMatchingId()
        {
            _mockRepository.Setup(x => x.GetById(_entity.Id)).Returns(_entity);

            var result = _mockRepository.Object.GetById(_entity.Id);

            Assert.Equal(_entity, result);
        }

        [Fact]
        public void Create_AddsNewEntityToDatabase()
        {
            _mockRepository.Setup(x => x.Create(_entity));

            _mockRepository.Object.Create(_entity);

            _mockRepository.Verify(x => x.Create(_entity), Times.Once());
        }

        [Fact]
        public void Update_UpdatesEntityInDatabase()
        {
            _mockRepository.Setup(x => x.Update(_entity));

            _mockRepository.Object.Update(_entity);

            _mockRepository.Verify(x => x.Update(_entity), Times.Once());
        }
    }
}