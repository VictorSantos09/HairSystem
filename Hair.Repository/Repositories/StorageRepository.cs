using Hair.Domain.Entities;
using Repository.Repository;

namespace Hair.Repository.Repositories
{
    public class StorageRepository : BaseRepository<SaloonItemEntity>
    {
        public StorageRepository(string pathFile) : base("StorageItens")
        {
        }
    }
}
