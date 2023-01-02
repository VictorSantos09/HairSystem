using Hair.Domain.Entities;

namespace Repository.Repository
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base("User")
        {

        }
        public UserEntity? GetByEmail(string email, string password)
        {
            return GetAll().Find(x => x.Email == email && x.Password == password);
        }
    }
}