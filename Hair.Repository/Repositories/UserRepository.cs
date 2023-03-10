using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks.Dataflow;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : IBaseRepository<UserEntity>, IGetByEmail
    {
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public UserRepository(IBaseRepository<HaircutEntity> haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public void Create(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute("dbo.spCreateUser", new
                {
                    ID = user.Id,
                    SALOON_NAME = user.SaloonName,
                    OWNER_NAME = CryptoSecurity.Encrypt(user.OwnerName),
                    PHONE_NUMBER = CryptoSecurity.Encrypt(user.PhoneNumber),
                    EMAIL = CryptoSecurity.Encrypt(user.Email),
                    PASSWORD = CryptoSecurity.Encrypt(user.Password),
                    CNPJ = user.CNPJ == null ? null : CryptoSecurity.Encrypt(user.CNPJ),
                    OPEN_TIME = user.OpenTime.ToString(),
                    GOOGLE_MAPS_SOURCE = user.GoogleMapsSource,
                    CLOSE_TIME = user.CloseTime.ToString(),
                    STREET = user.Address.Street,
                    NUMBER = user.Address.Number,
                    CITY = user.Address.City,
                    STATE = user.Address.State,
                    COMPLEMENT = user.Address.Complement == null ? null : user.Address.Complement,
                    CEP = user.Address.CEP,
                    HAIR = user.Prices.Hair,
                    BEARD = user.Prices.Beard,
                    MUSTACHE = user.Prices.Mustache,
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spUpdateUser");
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = conn.Query<UserEntity>("dbo.spGetUserByEmail @EMAIL, @PASSWORD", new
                {
                    EMAIL = CryptoSecurity.Encrypt(email),
                    PASSWORD = CryptoSecurity.Encrypt(password)
                }).FirstOrDefault();

                PopulateHaircut(user);

                return user == null ? null : user;
            }
        }

        public UserEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = conn.Query<UserEntity>("dbo.spGetUserById @ID", new { ID = id }).FirstOrDefault();

                PopulateHaircut(user);

                return user == null ? null : user;
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var usersFromSql = conn.Query<UserEntityFromSql>("dbo.spGetAllUsers").ToList();

                foreach (var userSql in usersFromSql)
                {
                    var user = DecryptProcess(userSql);
                    PopulateHaircut(user);
                    output.Add(user);
                }
            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = GetById(id);

                conn.Query("dbo.spRemoveUser @ID", new { ID = id });

                foreach (var haircut in user.Haircuts)
                {
                    _haircutRepository.Remove(haircut.Id);
                }

                return true;
            }
        }

        private void PopulateHaircut(UserEntity user)
        {
            if (user == null)
                return;

            var haircuts = _haircutRepository.GetAll().FindAll(x => x.SaloonId == user.Id);

            user.Haircuts.AddRange(haircuts);
        }

        private UserEntity DecryptProcess(UserEntityFromSql userSql)
        {
            var user = new UserEntity();

            user.CNPJ = userSql.CNPJ == null ? null : CryptoSecurity.Decrypt(userSql.CNPJ);
            user.Password = CryptoSecurity.Decrypt(userSql.Password);
            user.Email = CryptoSecurity.Decrypt(userSql.Email);
            user.PhoneNumber = CryptoSecurity.Decrypt(userSql.PhoneNumber);
            user.OwnerName = CryptoSecurity.Decrypt(userSql.OwnerName);

            return user;
        }
    }
}