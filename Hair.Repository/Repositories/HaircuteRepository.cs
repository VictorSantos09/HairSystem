using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using Dapper;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircuteEntity"/>.
    /// </summary>
    public class HaircuteRepository : BaseRepository<HaircuteEntity>, ICreateUpdate<HaircuteEntity>, IBaseRepository<HaircuteEntity>
    { 
        public HaircuteRepository() : base("HAIRCUTS")
        {
        }
        public void Create(HaircuteEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO HAIRCUTS (SALOON_ID, HAIRCUT_TIME, AVAILABLE) VALUES ('{haircute.SaloonId}', '{haircute.HaircuteTime}', '{haircute.Avaible}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
        public void Update(HaircuteEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE HAIRCUTS SET SALOON_ID = {haircute.SaloonId}, HAIRCUT_TIME = {haircute.HaircuteTime}, AVAILABLE = {haircute.Avaible}");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}