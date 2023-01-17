using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso de usuarios da entidade <see cref="UserEntity"/>
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base("User")
        {

           
        }
        //public UserEntity? GetByEmail(string email, string password)
        //{
        //    return GetAll().Find(x => x.Email == email.ToUpper() && x.Password == password);
        //}


        public void AddUser(UserEntity userEntity)
        {
            var user = new UserEntity()
            {
                Id = userEntity.Id,
                SaloonName = userEntity.SaloonName,
                OwnerName = userEntity.OwnerName,
                PhoneNumber = userEntity.PhoneNumber,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Adress = userEntity.Adress,
                CNPJ = userEntity.CNPJ,
                PriceEntity = userEntity.PriceEntity,
            };
            user.Create(); // Referência do método de criação no comando transact no UserEntity //
            return;
        }


    }

}
