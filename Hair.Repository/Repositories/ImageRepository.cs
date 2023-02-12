using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;


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
                var query = new SqlCommand($"INSERT INTO {TableName} (SALOON_IMAGE_ID, SOURCE, IMAGE) VALUES ('{image.SaloonId}', '{image.Source}', '{image.Img}')", conn);
                conn.Open();
            }
        }

        public void Update(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET SALOON_IMAGE_ID = {image.SaloonId}, SOURCE = {image.Source}, IMAGE = {image.Img}");
                conn.Open();
            }
        }
    }
}