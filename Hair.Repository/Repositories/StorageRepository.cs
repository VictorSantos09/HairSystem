using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    public class StorageRepository : BaseRepository<SaloonItemEntity>
    {
        public StorageRepository() : base("StorageItens")
        {
        }
    }
}
