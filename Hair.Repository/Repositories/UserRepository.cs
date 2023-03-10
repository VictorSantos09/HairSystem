using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : IBaseRepository<UserEntity>, IGetByEmail
    {
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;
        private readonly IBaseRepository<AddressEntity> _addressRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IBaseRepository<HaircutPriceEntity> _priceRepository;

        public UserRepository(IBaseRepository<HaircutEntity> haircutRepository, IBaseRepository<AddressEntity> addressRepository,
            IBaseRepository<BarberEntity> barberRepository, IBaseRepository<HaircutPriceEntity> priceRepository)
        {
            _haircutRepository = haircutRepository;
            _addressRepository = addressRepository;
            _barberRepository = barberRepository;
            _priceRepository = priceRepository;
        }

        public void Create(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var addressFk = _addressRepository.GetById(user.Id);
                var haircutFk = _haircutRepository.GetById(user.Id);
                var barberFk = _barberRepository.GetById(user.Id);
                var priceFk = _priceRepository.GetById(user.Id);

                conn.Execute("dbo.spCreateUser", new
                {
                    ID = user.Id,
                    SALOON_NAME = user.SaloonName,
                    OWNER_NAME = user.OwnerName,
                    PHONE_NUMBER = user.PhoneNumber,
                    EMAIL = user.Email,
                    PASSWORD = user.Password,
                    CNPJ = user.CNPJ,
                    OPEN_TIME = user.OpenTime.ToString(),
                    GOOGLE_MAPS_SOURCE = user.GoogleMapsSource,
                    CLOSE_TIME = user.CloseTime.ToString(),
                    FULL_ADDRESS = user.Address.FullAddress,
                    ADDRESS_FK = addressFk,
                    HAIRCUT_FK = haircutFk,
                    BARBER_FK = barberFk,
                    PRICE_FK = priceFk
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute("dbo.spUpdateUser",
                    new
                    {
                        ID = user.Id,
                        SALOON_NAME = user.SaloonName,
                        EMAIL = CryptoSecurity.Encrypt(user.Email),
                        PASSWORD = CryptoSecurity.Encrypt(user.Password),
                    });
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cipherEmail = CryptoSecurity.Encrypt(email);
                var cipherPassword = CryptoSecurity.Encrypt(password);

                var user = conn.Query<UserEntity>("dbo.spGetUserByEmail",
                    new { Email = cipherEmail, Password = cipherPassword },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                PopulateHaircut(user);

                return user;
            }
        }

        public UserEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = conn.Query<UserEntity>("dbo.spGetUserById",
                    new { ID = id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                PopulateHaircut(user);

                return user == null ? null : user;  
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var users = conn.Query<UserEntity>("dbo.spGetAllUsers",
                    commandType: CommandType.StoredProcedure).ToList();

                foreach (var user in users)
                {
                    PopulateHaircut(user);
                }
            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = GetById(id);

                conn.Execute("dbo.spDeleteUser",
                    new { ID = id },
                    commandType: CommandType.StoredProcedure);

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
    }
}