using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update itens do salão no banco de dados contidos na <see cref="SaloonItemEntity"/>.
    /// </summary>
    public class StorageRepository : IBaseRepository<SaloonItemEntity>
    {
        public void Create(SaloonItemEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<SaloonItemEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public SaloonItemEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SaloonItemEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}