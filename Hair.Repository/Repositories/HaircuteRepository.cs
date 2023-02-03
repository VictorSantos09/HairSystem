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
    public class HaircuteRepository : BaseRepository<HaircuteEntity>, ICreateUpdate<HaircuteEntity>
    {
        /// <summary>
        /// Construtor da classe.
        /// Chama o construtor da classe base passando o nome da tabela "HAIRCUTS".
        /// </summary>
        public HaircuteRepository() : base("HAIRCUTS")
        {
        }
        /// <summary>
        /// Método responsável por criar um novo salão na base de dados.
        /// </summary>
        /// <param name="haircute">Entidade HaircuteEntity com os dados do salão a ser criado.</param>
        public void Create(HaircuteEntity haircute)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO HAIRCUTS (SALOON_ID, HAIRCUT_TIME, AVAILABLE) VALUES ('{haircute.SaloonId}', '{haircute.HaircuteTime}', '{haircute.Avaible}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Método responsável por atualizar os dados de um salão na base de dados.
        /// </summary>
        /// <param name="haircute">Entidade HaircuteEntity com os dados atualizados do salão.</param>
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