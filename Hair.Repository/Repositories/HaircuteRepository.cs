using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using Dapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório para acessar dados referentes aos cortes de cabelo
    /// 
    /// <para>Tais como horarios, cliente e se disponivel da entidade <see cref="HaircuteEntity"/> </para>
    /// </summary>
    public class HaircuteRepository : BaseRepository<HaircuteEntity>
    {
        public HaircuteRepository() : base("HaircuteTime")
        {

        }

        public void Create(HaircuteEntity haircute)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"INSERT INTO HAIRCUTS (SALOON_ID, HAIRCUT_TIME, AVAILABLE, CLIENT_NAME, CLIENT_EMAIL, CLIENT_PHONE_NUMBER) 
                  VALUES (@Id, @SaloonId, @HaircuteTime, @Avaible, @ClientName, @ClientEmail, @ClientPhoneNumber)";
                var affectedRows = connection.Execute(query, new
                {
                    Id = Guid.NewGuid(),
                    haircute.SaloonId,
                    haircute.HaircuteTime,
                    haircute.Avaible,
                    haircute.Client.Name,
                    haircute.Client.Email,
                    haircute.Client.PhoneNumber
                });
            }
        }

        public void Read(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "SELECT * FROM HAIRCUTS WHERE ID = @Id";
                var haircute = connection.QueryFirstOrDefault<HaircuteEntity>(query, new { id });
                var client = new ClientEntity(haircute.Client.Name, haircute.Client.Email, haircute.Client.PhoneNumber);
                haircute.Client = client;
            }
        }

        public void Update(HaircuteEntity haircute)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"UPDATE HAIRCUTS SET SALOON_ID = @SaloonId, HAIRCUT_TIME = @HaircuteTime, AVAILABLE = @Avaible,
                 CLIENT_NAME = @ClientName, CLIENT_EMAIL = @ClientEmail, CLIENT_PHONE_NUMBER = @ClientPhoneNumber
                  WHERE Id = @Id";
                var affectedRows = connection.Execute(query, new
                {
                    haircute.SaloonId,
                    haircute.HaircuteTime,
                    haircute.Avaible,
                    haircute.Client.Name,
                    haircute.Client.Email,
                    haircute.Client.PhoneNumber,
                    haircute.Id
                });
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "DELETE FROM HAIRCUTS WHERE ID = @Id";
                var affectedRows = connection.Execute(query, new { id });
            }
        }
    }
}