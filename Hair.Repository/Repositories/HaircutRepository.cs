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
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircutEntity"/>.
    /// </summary>
    public class HaircutRepository : IBaseRepository<HaircutEntity>
    {
        public HaircutRepository()
        {
        }
        public void Create(HaircutEntity haircut)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spCreateHaircut @HAIRCUT_ID, @HAIRCUT_TIME, @AVAILABLE, @SALOON_ID, " +
                    "@CLIENT_FK, @CLIENT_NAME, @CLIENT_EMAIL, @CLIENT_PHONE_NUMBER", new
                {
                    HAIRCUT_ID = haircut.Id,
                    HAIRCUT_TIME = haircut.HaircuteTime,
                    AVAILABLE = haircut.Available,
                    SALOON_ID = haircut.SaloonId,
                    CLIENT_FK = haircut.Client.Id,
                    CLIENT_NAME = CryptoSecurity.Encrypt(haircut.Client.Name),
                    CLIENT_EMAIL = CryptoSecurity.Encrypt(haircut.Client.Email),
                    CLIENT_PHONE_NUMBER = CryptoSecurity.Encrypt(haircut.Client.PhoneNumber)
                });
            }
        }

        public void Update(HaircutEntity haircut)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {

            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spRemoveHaircut", new { ID = id });
                return true;
            }
        }
        public List<HaircutEntity> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<HaircutEntity>("dbo.spGetAllHaircuts").ToList();
            }
        }
        public HaircutEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var haircut = conn.Query<HaircutEntity>("dbo.spGetHaircutById", new { ID = id }).FirstOrDefault();
                return haircut == null ? null : haircut;
            }
        }
    }
}