﻿using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Services
{
    public class ViewHaircutTimeServiceTests
    {
        private readonly ViewHaircutTimeService _service;
        private readonly Mock<IBaseRepository<DutyEntity>> _repositoryMock;
        public ViewHaircutTimeServiceTests()
        {
            _repositoryMock = new Mock<IBaseRepository<DutyEntity>>();
            _service = new ViewHaircutTimeService(_repositoryMock.Object);
        }

        [Fact]
        public void GetScheduledHaircuts_WithValidUserId_Returns_BaseDtoWithHaircutsList()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedHaircuts = new List<DutyEntity>
            {
                new DutyEntity { Id = Guid.NewGuid(), UserID = userId },
                new DutyEntity { Id = Guid.NewGuid(), UserID = userId}
            };

            var dto = new ViewHaircutTimeDto(userId);
            _repositoryMock.Setup(x => x.GetAll()).Returns(expectedHaircuts);

            // Act
            var result = _service.GetScheduledHaircuts(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result._StatusCode);
            Assert.Equal("Lista de cortes agendados encontrados.", result._Message);
            Assert.Equal(expectedHaircuts, result._Data);
        }

        [Fact]
        public void GetScheduledHaircuts_WithInvalidUserId_Returns_BaseDtoWithErrorMessage()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var expectedHaircuts = new List<DutyEntity>
            {
                new DutyEntity { Id = Guid.NewGuid(), UserID = Guid.NewGuid()}
            };

            var dto = new ViewHaircutTimeDto(userId);
            _repositoryMock.Setup(x => x.GetAll()).Returns(expectedHaircuts);

            // Act
            var result = _service.GetScheduledHaircuts(dto);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result._StatusCode);
            Assert.Equal("Não foram encontrados cortes agendados para este usuário.", result._Message);
            Assert.Null(result._Data);
        }
    }
}