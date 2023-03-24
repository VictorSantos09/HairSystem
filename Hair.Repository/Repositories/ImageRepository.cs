using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.Repositories;
using System.Data;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : IImageRepository
    {
        public void Create(ImageEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateImage @ID, @USERID, @IMAGE", new
                {
                    ID = entity.Id,
                    USERID = entity.UserID,
                    IMAGE = entity.Image
                });
            }
        }

        public List<ImageEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<ImageEntity>("dbo.spGetAllImages").ToList();
            }
        }

        public ImageEntity? GetById(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<ImageEntity>("dbo.spGetImageById", new { ID = id }).FirstOrDefault();
            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spDeleteImage", new { ID = id });
            }

            return true;
        }

        public void Update(ImageEntity entity)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateImage", new { ID = entity.Id, IMAGE = entity.Image, @SALOON_ID = entity.UserID });
            }
        }
    }
}