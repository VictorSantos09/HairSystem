using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>, IBaseRepository<UserEntity>
    {
        /// <summary>
        /// Construtor da classe.
        /// Chama o construtor da classe base passando o nome da tabela "USERS".
        /// </summary>
        public UserRepository() : base("USERS")
        {

        }
        /// <summary>
        /// Método responsável por adicionar um novo usuário na base de dados.
        /// </summary>
        /// <param name="user">Entidade UserEntity com os dados do usuário a ser adiciondo.</param>
        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO USERS (ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE) VALUES ('{user.Id}', '{user.SaloonName}','{user.OwnerName}','{user.PhoneNumber}','{user.Email}','{user.Password}'," +
                    $"'{user.Adress}','{user.CNPJ}','{user.Haircutes}','{user.PriceEntity}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Método responsável por atualizar os dados de um usuário na base de dados.
        /// </summary>
        /// <param name="user">Entidade UserEntity com os dados atualizados do usuário.</param>
        public void Update(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE USERS SET ID = {user.Id}, SALOON_NAME = {user.SaloonName}, OWNER_NAME = {user.SaloonName}, PHONE_NUMBER = {user.PhoneNumber}, EMAIL = {user.Email}, PASSWORD = {user.Password}," +
                    $" ADDRESS = {user.Adress}, CNPJ = {user.CNPJ}, HAIRCUT_TIME = {user.Haircutes}, HAIRCUT_PRICE='{user.PriceEntity}'");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}