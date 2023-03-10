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
        private readonly static string TableName = "IMAGES";

        public void Create(ImageEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute("spCreateImage", new { Id = entity.Id, UserId = entity.SaloonId, Image = entity.Img }, commandType: CommandType.StoredProcedure);
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

        public ImageEntity? GetByUserId(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var result = conn.Query<ImageEntity>("spGetImagesByUserId", new { UserId = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                int rowsAffected = conn.Execute("spDeleteImage", new { Id = id }, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }

        public void Update(ImageEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}