using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="IHaircut"/>.
    /// </summary>
    public class HaircutRepository : IBaseRepository<IHaircut>
    {
        private readonly static string TableName = "HAIRCUTS";
        public HaircutRepository()
        {
        }
        public void Create(IHaircut haircut)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO {TableName} VALUES (@SALOON_ID, @HAIRCUT_TIME, @AVAILABLE, @CLIENT_NAME, @CLIENT_EMAIL, @CLIENT_PHONE_NUMBER, @ID)", conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@SALOON_ID", haircut.SaloonId);
                cmd.Parameters.AddWithValue("@HAIRCUT_TIME", haircut.HaircuteTime);
                cmd.Parameters.AddWithValue("@AVAILABLE", haircut.Avaible);
                cmd.Parameters.AddWithValue("@CLIENT_NAME", haircut.Client.Name);
                cmd.Parameters.AddWithValue("@CLIENT_EMAIL", haircut.Client.Email);
                cmd.Parameters.AddWithValue("@CLIENT_PHONE_NUMBER", haircut.Client.PhoneNumber);
                cmd.Parameters.AddWithValue("@ID", haircut.Id);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(IHaircut haircut) // QUEBRANDO
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"UPDATE {TableName} SET HAIRCUT_TIME= @HAIRCUTE_TIME, AVAILABLE= @AVAILABLE, SALOON_ID= @SALOON_ID, " +
                    $"CLIENT_NAME= @CLIENT_NAME, CLIENT_EMAIL= @CLIENT_EMAIL, CLIENT_PHONE_NUMBER= @CLIENT_PHONE_NUMBER, ID= @ID WHERE SALOON_ID = @SaloonId");

                conn.Open();

                cmd.Parameters.AddWithValue("@HAIRCUT_TIME", haircut.HaircuteTime);
                cmd.Parameters.AddWithValue("@AVAILABLE", haircut.Avaible);
                cmd.Parameters.AddWithValue("@SALOON_ID", haircut.SaloonId);
                cmd.Parameters.AddWithValue("@CLIENT_NAME", haircut.Client.Name);
                cmd.Parameters.AddWithValue("@CLIENT_EMAIL", haircut.Client.Email);
                cmd.Parameters.AddWithValue("@CLIENT_PHONE_NUMBER", haircut.Client.PhoneNumber);
                cmd.Parameters.AddWithValue("@ID", haircut.Id);

                cmd.ExecuteNonQuery();
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

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                return true;
            }
        }
        public List<IHaircut> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var haircuts = new List<IHaircut>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IHaircut haircut = new HaircutEntity();

                        haircut.Id = reader.GetGuid("ID");
                        haircut.SaloonId = reader.GetGuid("SALOON_ID");
                        haircut.Avaible = reader.GetBoolean("AVAILABLE");
                        haircut.HaircuteTime = reader.GetDateTime("HAIRCUT_TIME");
                        haircut.Client.PhoneNumber = reader.GetString("CLIENT_PHONE_NUMBER");
                        haircut.Client.Email = reader.GetString("CLIENT_EMAIL");
                        haircut.Client.Name = reader.GetString("CLIENT_NAME");

                        haircuts.Add(haircut);
                    }
                }

                return haircuts;
            }
        }
        public IHaircut? GetById(Guid id)
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

        private IHaircut? BuildEntity(SqlCommand cmd)
        {
            HaircutEntity? haircut = new HaircutEntity();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    haircut.HaircuteTime = reader.GetDateTime("HAIRCUT_TIME");
                    haircut.Avaible = reader.GetBoolean("AVAILABLE");
                    haircut.Id = reader.GetGuid("ID");
                    haircut.SaloonId = reader.GetGuid("ID");
                    haircut.Client.Name = reader.GetString("CLIENT_NAME");
                    haircut.Client.Email = reader.GetString("CLIENT_EMAIL");
                    haircut.Client.PhoneNumber = reader.GetString("CLIENT_PHONE_NUMBER");

                }
            }
            return haircut.Id == Guid.Empty ? null : haircut;
        }
    }
}