using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de imagens no banco de dados contidas na <see cref="ImageEntity"/>.
    /// </summary>
    public class ImageRepository : BaseRepository<ImageEntity>, ICreateUpdate<ImageEntity>
    {
        public ImageRepository() : base("IMAGES")
        {
        }
        public void Create(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO IMAGES (SALOON_IMAGE_ID, SOURCE, IMAGE) VALUES ('{image.SaloonId}', '{image.Source}', '{image.Img}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
        public void Update(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE IMAGES SET SALOON_IMAGE_ID = {image.SaloonId}, SOURCE = {image.Source}, IMAGE = {image.Img}");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}
