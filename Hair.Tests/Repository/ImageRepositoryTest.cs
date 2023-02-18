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

    }
}
