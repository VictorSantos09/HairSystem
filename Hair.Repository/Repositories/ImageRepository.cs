using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : IBaseRepository<ImageEntity>
    {
        public void Create(ImageEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spCreateImage @ID, @USER_ID, @IMAGE", new
                {
                    ID = entity.Id,
                    USER_ID = entity.SaloonId,
                    IMAGE = entity.Img
                });
            }
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