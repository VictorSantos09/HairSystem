using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    public class AddressRepository : IBaseRepository<AddressEntity>
    {
        public void Create(AddressEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {

            }
        }

        public List<AddressEntity> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<AddressEntity>("dbo.spGetAllAddresses").ToList();
            }
        }

        public AddressEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);

                return conn.Query<AddressEntity>("dbo.spGetAddressById", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spRemoveAddress", new { ID = id });
            }

            return true;
        }

        public void Update(AddressEntity entity)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {

            }
        }
    }
}
