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
    public class ImageRepository : BaseRepository<ImageEntity>, ICreateUpdate<ImageEntity>
    {
        public ImageRepository() : base("IMAGES")
        {
        }

        public void Create(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO IMAGES (SALOON_IMAGE_ID, SOURCE, IMAGE) VALUES ('{image.SaloonImageId}', '{image.Source}', '{image.Img}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }

        public void Update(ImageEntity image)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE IMAGES SET SALOON_IMAGE_ID = {image.SaloonImageId}, SOURCE = {image.Source}, IMAGE = {image.Img}");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}
