using Hair.Domain.Entities;
using Hair.Repository.Interfaces;


namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : IBaseRepository<ImageEntity>
    {
        public void Create(ImageEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<ImageEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImageEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}