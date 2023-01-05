using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base("User")
        {

        }
        public UserEntity? GetByEmail(string email, string password)
        {
            return GetAll().Find(x => x.Email == email.ToUpper() && x.Password == password);
        }
    }
}