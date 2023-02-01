using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using Dapper;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório para acessar dados referentes aos cortes de cabelo
    /// 
    /// <para>Tais como horarios, cliente e se disponivel da entidade <see cref="HaircuteEntity"/> </para>
    /// </summary>
    public class HaircuteRepository : BaseRepository<HaircuteEntity>, ICreateUpdate<HaircuteEntity>
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