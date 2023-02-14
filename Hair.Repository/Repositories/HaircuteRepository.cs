using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircuteEntity"/>.
    /// </summary>
    public class HaircuteRepository : BaseRepository<HaircuteEntity>, ICreateUpdate<HaircuteEntity>, IBaseRepository<HaircuteEntity>
    {
        private readonly static string TableName = "HAIRCUTS";
        public HaircuteRepository() : base(TableName)
        {
        }
        public void Create(HaircuteEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName}  VALUES (@SALOON_ID, @HAIRCUT_TIME, @AVAILABLE)");

                conn.Open();

                query.Parameters.AddWithValue("@SALOON_ID", haircute.SaloonId);
                query.Parameters.AddWithValue("@SALOON_ID", haircute.HaircuteTime);
                query.Parameters.AddWithValue("@SALOON_ID", haircute.Avaible);

                query.ExecuteNonQueryAsync();
            }
        }
        public void Update(HaircuteEntity haircute)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET HAIRCUT_TIME = {haircute.HaircuteTime}, AVAILABLE = {haircute.Avaible} WHERE SALOON_ID = {haircute.SaloonId}");
                conn.Open();
            }
        }
    }
}