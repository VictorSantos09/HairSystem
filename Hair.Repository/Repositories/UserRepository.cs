using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Repository.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IBaseRepository<UserEntity>
    {
        private readonly IBaseRepository<UserEntity> _baseRepository;
        public UserRepository(IBaseRepository<UserEntity> baseRepository) : base("User")
        {
            _baseRepository = baseRepository;
        }
        public UserEntity? GetByEmail(string email, string password)
        {
            return GetAll().Find(x => x.Email == email && x.Password == password);
        }
    }
}