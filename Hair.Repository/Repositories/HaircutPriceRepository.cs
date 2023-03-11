using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    public class HaircutPriceRepository : IGetByUserId<HaircutPriceEntity>
    {
        public void Create(HaircutPriceEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<HaircutPriceEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public HaircutPriceEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);

                return conn.Query<HaircutPriceEntity>("dbo.spGetHaircutPricebyId", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public HaircutPriceEntity? GetByUserId(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<HaircutPriceEntity>("dbo.spAlgo", new { USER_ID = user.Id }).FirstOrDefault();
            }
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(HaircutPriceEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}