using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;


namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : BaseRepository<ImageEntity>, ICreateUpdate<ImageEntity>, IBaseRepository<ImageEntity>
    {
        private readonly static string TableName = "IMAGES";
        public ImageRepository() : base(TableName)
        {
        }

        public void Create(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName} (@SALOON_IMAGE_ID, @IMAGE)");

                conn.Open();
          
                query.Parameters.AddWithValue("@SALOON_IMAGE_ID", image.SaloonId);
                query.Parameters.AddWithValue("@IMAGE", image.Img); 

                query.ExecuteNonQueryAsync();
            }
        }

        public void Update(ImageEntity image)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET IMAGE = @Img WHERE SALOON_IMAGE_ID = @SaloonId");

                conn.Open();

                query.Parameters.AddWithValue("@IMAGE", image.Img);
                query.Parameters.AddWithValue("@SALOON_IMAGE_ID", image.SaloonId);

                query.ExecuteNonQueryAsync();
            }
        }
    }
}