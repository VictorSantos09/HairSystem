using Hair.Domain.Entities;
using Hair.Repository.Interfaces.CRUD;

namespace Hair.Repository.Interfaces.Repositories
{
    public interface IImageRepository : IApplicationDbContext<ImageEntity>, IGetAllByUserIdDbContext<ImageEntity>
    {
    }
}
