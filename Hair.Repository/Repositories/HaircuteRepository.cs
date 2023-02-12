using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
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
                var query = new SqlCommand($"INSERT INTO {TableName} (SALOON_ID, HAIRCUT_TIME, AVAILABLE) VALUES ('{haircute.SaloonId}', '{haircute.HaircuteTime}', '{haircute.Avaible}')", conn);
                conn.Open();
            }
        }
        public void Update(HaircuteEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET SALOON_ID = {haircute.SaloonId}, HAIRCUT_TIME = {haircute.HaircuteTime}, AVAILABLE = {haircute.Avaible}");
                conn.Open();
            }
        }
    }
}