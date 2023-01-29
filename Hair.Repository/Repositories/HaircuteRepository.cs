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
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"INSERT INTO HAIRCUTS (SALOON_ID = {haircute.Id}, HAIRCUT_TIME = {haircute.HaircuteTime}, AVAILABLE = {haircute.Avaible}, " +
                    $"CLIENT_NAME = {haircute.Client.Name}, CLIENT_EMAIL = {haircute.Client.Email}, CLIENT_PHONE_NUMBER = {haircute.Client.PhoneNumber})";
                connection.Execute(query);
            }
        }

        public void Update(HaircuteEntity haircute)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE HAIRCUTS SET SALOON_ID = {haircute.SaloonId}, HAIRCUT_TIME = {haircute.HaircuteTime}, AVAILABLE = {haircute.Avaible}";
                connection.Execute(query);
            }
        }
    }
}