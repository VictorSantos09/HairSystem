using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;


namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : BaseRepository<IImage>, IBaseRepository<IImage>
    {
        private readonly static string TableName = "IMAGES";
        public ImageRepository() : base(TableName)
        {
        }

        public void Create(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO {TableName} (@SALOON_ID, @IMAGE, @ID)");

                conn.Open();

                cmd.Parameters.AddWithValue("@SALOON_ID", image.SaloonId);
                cmd.Parameters.AddWithValue("@IMAGE", image.Img);
                cmd.Parameters.AddWithValue("@ID", image.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Create(IUser entity)
        {
            throw new NotImplementedException();
        }

        public void Create(IImage entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageEntity image)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"UPDATE {TableName} SET IMAGE = @IMAGE WHERE SALOON_ID = @SaloonId");

                conn.Open();

                cmd.Parameters.AddWithValue("@IMAGE", image.Img);
                cmd.Parameters.AddWithValue("@SALOON_ID", image.SaloonId);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(IUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IImage entity)
        {
            throw new NotImplementedException();
        }
    }
}