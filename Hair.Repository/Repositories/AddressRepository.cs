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
            throw new NotImplementedException();
        }

        public AddressEntity? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(AddressEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
