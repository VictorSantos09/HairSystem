using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircutEntity"/>.
    /// </summary>
    public class HaircutRepository : BaseRepository<HaircutEntity>, ICreateUpdate<HaircutEntity>, IBaseRepository<HaircutEntity>
    {
        private readonly static string TableName = "HAIRCUTS";
        public HaircutRepository() : base(TableName)
        {
        }
        public void Create(HaircutEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName}  VALUES (@SALOON_ID, @HAIRCUT_TIME, @AVAILABLE)");

                conn.Open();

                query.Parameters.AddWithValue("@SALOON_ID", haircute.SaloonId);
                query.Parameters.AddWithValue("@HAIRCUT_TIME", haircute.HaircuteTime);
                query.Parameters.AddWithValue("@AVAILABLE", haircute.Avaible);

                query.ExecuteNonQueryAsync();
            }
        }
        public void Update(HaircutEntity haircute)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET HAIRCUT_TIME = @HaircuteTime, AVAILABLE = @Avaible WHERE SALOON_ID = @SaloonId");

                conn.Open();

                query.Parameters.AddWithValue("@HAIRCUT_TIME", haircute.HaircuteTime);
                query.Parameters.AddWithValue("@AVAILABLE", haircute.Avaible);
                query.Parameters.AddWithValue("@SALOON_ID", haircute.SaloonId);

                query.ExecuteNonQueryAsync();
            }
        }
    }
}