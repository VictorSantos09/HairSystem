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
    public class ImageRepository :IBaseRepository<IImage>
    {
        private readonly static string TableName = "IMAGES";
        public void Create(IImage image)
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

        public List<IImage> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var images = new List<IImage>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IImage image = new ImageEntity();

                        image.Id = reader.GetGuid("ID");
                        image.SaloonId = reader.GetGuid("SALOON_ID");
                        //image.Img = reader.GetString("IMAGE");

                        images.Add(image);
                    }
                }

                return images;
            }
        }

        public IImage? GetById(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName} WHERE Id= @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                return BuildEntity(cmd);
            }
        }

        public bool Remove(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"DELETE FROM {TableName} WHERE ID= @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                var user = GetById(id);

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                return true;
            }
        }

        public void Update(IImage image)
        {

        }

        private IImage? BuildEntity(SqlCommand cmd)
        {
            IImage? image = new ImageEntity();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    image.Id = reader.GetGuid("ID");
                    image.SaloonId = reader.GetGuid("SALOON_ID");
                    //image.Img = reader.GetByte("IMAGE"); corrigir
                }
            }
            return image.Id == Guid.Empty ? null : image;
        }
    }
}